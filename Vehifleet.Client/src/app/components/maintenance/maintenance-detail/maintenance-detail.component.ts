import { Component, OnInit } from '@angular/core';
import { Maintenance } from 'src/app/classes/maintenance/maintenance';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { DatepickerConverterService } from 'src/app/shared/datepicker/datepicker-converter.service';
import { VehicleService } from 'src/app/services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseFormDetailComponent } from '../../base/base-form-detail.component';
import { ModalService } from 'src/app/shared/modal/modal.service';
import { timeSpanValidator } from 'src/app/shared/validators/validators';

@Component({
  selector: 'app-maintenance-detail',
  templateUrl: './maintenance-detail.component.html',
  styleUrls: ['./maintenance-detail.component.scss']
})
export class MaintenanceDetailComponent extends BaseFormDetailComponent {
  maintenance: Maintenance;
  vehicle: Vehicle;
  form = new FormGroup(
    {
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl(''),
      description: new FormControl('', Validators.required),
      mileage: new FormControl('', Validators.required),
      cost: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]*$')
      ])
    },
    { validators: timeSpanValidator }
  );

  constructor(
    private maintenanceService: MaintenanceService,
    private datePickerConverter: DatepickerConverterService,
    private vehicleService: VehicleService,
    private modalService: ModalService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    super();
  }

  get() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id != 0) {
      this.maintenanceService.getById(id).subscribe(maintenance => {
        this.maintenance = maintenance;
        this.maintenance.startDate = new Date(maintenance.startDate);
        this.maintenance.endDate = new Date(maintenance.endDate);
        this.vehicleService
          .getById(this.maintenance.vehicleId)
          .subscribe(vehicle => {
            this.vehicle = vehicle;
            this.setUpForm();
          });
      });
    } else {
      this.maintenance = new Maintenance(0);
      this.maintenance.vehicleId = +this.route.snapshot.paramMap.get(
        'vehicleId'
      );
      this.maintenance.startDate = new Date();
      this.maintenance.endDate = this.datePickerConverter.addDays(
        new Date(),
        1
      );
      this.maintenance.cost = 0;
      this.vehicleService
        .getById(this.maintenance.vehicleId)
        .subscribe(vehicle => {
          this.vehicle = vehicle;
          this.maintenance.mileage = vehicle.mileage;
          this.setUpForm();
        });
    }
  }

  setUpForm() {
    this.form.patchValue({
      startDate: this.maintenance.startDate,
      endDate: this.maintenance.endDate,
      description: this.maintenance.description,
      mileage: this.maintenance.mileage,
      cost: this.maintenance.cost
    });
  }

  readForm() {
    this.maintenance.startDate = this.form.get('startDate').value;
    this.maintenance.endDate = this.form.get('endDate').value;
    this.maintenance.description = this.form.get('description').value;
    this.maintenance.mileage = this.form.get('mileage').value;
    this.maintenance.cost = this.form.get('cost').value;
  }

  onSubmit() {
    this.readForm();
    if (this.maintenance.id != 0) {
      this.maintenanceService
        .update(this.maintenance, this.maintenance.id)
        .subscribe(response => {
          if (response['status'] == 200) {
            this.modalService.showSuccessModal('Maintenance has been updated.');
          } else {
            this.modalService.showErrorModal('Maintenance update has failed.');
          }
        });
    } else {
      this.maintenanceService.create(this.maintenance).subscribe(id => {
        if (id != null) {
          this.modalService.showSuccessModal('Maintenance has been created.');
          this.router.navigate([
            `/vehicles/${this.maintenance.vehicleId}/maintenances/${id}`
          ]);
          this.get();
        } else {
          this.modalService.showSuccessModal(
            'Maintenance creation has failed.'
          );
        }
      });
    }
  }

  onDelete() {
    this.modalService
      .showConfirmModal('Do you want to delete this maintenance?')
      .then(confirmed => {
        if (confirmed == 'true') {
          this.maintenanceService
            .delete(this.maintenance.id)
            .subscribe(response => {
              if (response['status'] == 200) {
                this.modalService.showSuccessModal(
                  'Maintenance has been deleted.'
                );
                this.router.navigate([
                  `/vehicles/${this.maintenance.vehicleId}`
                ]);
              } else {
                this.modalService.showErrorModal(
                  'Maintenance deletion has failed.'
                );
              }
            });
        }
      });
  }
}
