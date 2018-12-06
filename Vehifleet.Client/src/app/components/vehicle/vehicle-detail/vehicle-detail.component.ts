import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { LocationService } from 'src/app/services/location.service';
import { BaseFormDetailComponent } from '../../base/base-form-detail.component';
import { ModalService } from 'src/app/shared/modal/modal.service';
import { VehicleModel } from 'src/app/classes/vehicle-model/vehicle-model';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.scss']
})
export class VehicleDetailComponent extends BaseFormDetailComponent {
  vehicle: Vehicle;
  form = new FormGroup({
    status: new FormControl('', Validators.required),
    locationCode: new FormControl('', Validators.required),
    canBeBookedUntil: new FormControl('', Validators.required),
    licensePlate: new FormControl('', Validators.required),
    yearOfManufacture: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]{3}$')
    ]),
    chassisCode: new FormControl('', Validators.required),
    inspectionValidUntil: new FormControl('', Validators.required),
    cost: new FormControl('', [
      Validators.required,
      Validators.pattern('^[0-9]*$')
    ]),
    fuelConsumed: new FormControl('', [
      Validators.required,
      Validators.pattern('^[0-9]*$')
    ]),
    mileage: new FormControl('', [
      Validators.required,
      Validators.pattern('^[0-9]*$')
    ])
  });
  locations: string[];
  statuses = [
    'Available',
    'Unavailable',
    'In Maintenance',
    'Awaiting Insurance Renewal',
    'Awaiting Inspection',
    'Decommissioned'
  ];
  canBeEdited: boolean;

  get newEntity(): boolean {
    return this.vehicle.id == 0;
  }

  constructor(
    private vehicleService: VehicleService,
    private vehicleModelService: VehicleModelService,
    private locationService: LocationService,
    private modalService: ModalService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    super();
  }

  get() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id != 0) {
      this.vehicleService.getById(id).subscribe(vehicle => {
        this.vehicle = vehicle;
        this.vehicle.canBeBookedUntil = vehicle.canBeBookedUntil;
        this.vehicle.inspectionValidUntil = new Date(
          vehicle.inspectionValidUntil
        );
        this.locationService.get().subscribe(locations => {
          this.locations = locations;
          this.setUpForm();
        });
      });
    } else {
      const vehicleModelId = +this.route.snapshot.paramMap.get(
        'vehicleModelId'
      );
      this.vehicle = new Vehicle(0);
      this.vehicleModelService
        .getById(vehicleModelId)
        .subscribe(vehicleModel => {
          this.vehicle.manufacturer = vehicleModel.manufacturer;
          this.vehicle.model = vehicleModel.model;
        });
      this.vehicle.vehicleModelId = vehicleModelId;
      this.vehicle.status = 'Available';
      this.locationService.get().subscribe(locations => {
        this.locations = locations;
        this.vehicle.locationCode = this.locations[0];
        this.setUpForm();
      });
      this.vehicle.canBeBookedUntil = new Date();
      this.vehicle.yearOfManufacture = new Date().getFullYear().toString();
      this.vehicle.inspectionValidUntil = new Date();
      this.vehicle.cost = 0;
      this.vehicle.fuelConsumed = 0;
      this.vehicle.mileage = 0;
    }
  }

  setUpForm() {
    this.form.patchValue({
      status: this.vehicle.status,
      canBeBookedUntil: this.vehicle.canBeBookedUntil,
      licensePlate: this.vehicle.licensePlate,
      yearOfManufacture: this.vehicle.yearOfManufacture,
      chassisCode: this.vehicle.chassisCode,
      inspectionValidUntil: this.vehicle.inspectionValidUntil,
      cost: this.vehicle.cost,
      fuelConsumed: this.vehicle.fuelConsumed,
      mileage: this.vehicle.mileage
    });
    this.form.controls['locationCode'].setValue(this.vehicle.locationCode);
    if (this.vehicle.status == 'Booked') {
      this.form.disable();
    }
  }

  readForm() {
    this.vehicle.status = this.form.get('status').value;
    this.vehicle.locationCode = this.form.get('locationCode').value;
    this.vehicle.canBeBookedUntil = this.form.get('canBeBookedUntil').value;
    this.vehicle.licensePlate = this.form.get('licensePlate').value;
    this.vehicle.yearOfManufacture = this.form.get('yearOfManufacture').value;
    this.vehicle.chassisCode = this.form.get('chassisCode').value;
    this.vehicle.inspectionValidUntil = this.form.get(
      'inspectionValidUntil'
    ).value;
    this.vehicle.cost = this.form.get('cost').value;
    this.vehicle.fuelConsumed = this.form.get('fuelConsumed').value;
    this.vehicle.mileage = this.form.get('mileage').value;
  }

  onSubmit() {
    this.readForm();
    if (this.vehicle.id != 0) {
      if (this.vehicle.status == 'Decomissioned') {
        this.modalService
          .showConfirmModal('Do you want to decomission this vehicle?')
          .then(confirmed => {
            if (confirmed != 'true') {
              return;
            }
          });
      }
      this.vehicleService
        .update(this.vehicle, this.vehicle.id)
        .subscribe(response => {
          if (response['status'] == 200) {
            this.modalService.showSuccessModal('Vehicle has been updated.');
          } else {
            this.modalService.showErrorModal('Vehicle update has failed.');
          }
        });
    } else {
      if (this.vehicle.status == 'Decomissioned') {
        this.modalService.showInfoModal(
          'New vehicle cannot be set as decomissioned.'
        );
        return;
      }
      this.vehicleService.create(this.vehicle).subscribe(id => {
        if (id != null) {
          this.modalService.showSuccessModal('Vehicle has been created.');
          this.router.navigate([`/vehicles/${id}`]);
        } else {
          this.modalService.showSuccessModal('Vehicle creation has failed.');
        }
      });
    }
  }

  onDelete() {
    this.modalService
      .showConfirmModal('Do you want to delete this vehicle?')
      .then(confirmed => {
        if (confirmed == 'true') {
          this.vehicleService.delete(this.vehicle.id).subscribe(response => {
            if (response['status'] == 200) {
              this.modalService.showSuccessModal('Vehicle has been deleted.');
              this.router.navigate([`/vehicles`]);
            } else {
              this.modalService.showErrorModal('Vehicle deletion has failed.');
            }
          });
        }
      });
  }
}
