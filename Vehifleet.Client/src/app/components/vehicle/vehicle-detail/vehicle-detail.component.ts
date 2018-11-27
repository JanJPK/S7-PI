import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { LocationService } from 'src/app/services/location.service';
import { BaseComponent } from 'src/app/components/base/base.component';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.scss']
})
export class VehicleDetailComponent extends BaseComponent {
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
    private locationService: LocationService,
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
        this.locationService.get().subscribe(locations => {
          this.locations = locations;
          this.setUpForm();
        });
      });
    } else {
      const vehicleModelId = +this.route.snapshot.paramMap.get(
        'vehicleModelId'
      );
      this.vehicle = new Vehicle();
      this.vehicle.status = 'Available';
      this.vehicle.vehicleModelId = vehicleModelId;
      this.vehicle.canBeBookedUntil = new Date();
      this.vehicle.yearOfManufacture = new Date().getFullYear().toString();
      this.vehicle.cost = 0;
      this.vehicle.fuelConsumed = 0;
      this.vehicle.mileage = 0;
      this.locationService.get().subscribe(locations => {
        this.locations = locations;
        this.vehicle.locationCode = this.locations[0];
        this.setUpForm();
      });
    }
  }

  setUpForm() {
    this.form.patchValue({
      status: this.vehicle.status,
      canBeBookedUntil: this.vehicle.canBeBookedUntil,
      licensePlate: this.vehicle.licensePlate,
      yearOfManufacture: this.vehicle.yearOfManufacture,
      chassisCode: this.vehicle.chassisCode,
      cost: this.vehicle.cost,
      fuelConsumed: this.vehicle.fuelConsumed,
      mileage: this.vehicle.mileage
    });
    this.form.controls['locationCode'].setValue(this.vehicle.locationCode);
    if (this.vehicle.status != 'Available') {
      this.form.disable();
    }
  }

  onSubmit() {
    throw new Error('Method not implemented.');
  }

  openVehicleModel() {
    this.router.navigate([`/vehicle-models/${this.vehicle.vehicleModelId}`]);
  }
}
