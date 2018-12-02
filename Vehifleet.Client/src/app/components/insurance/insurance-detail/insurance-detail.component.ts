import { Component, OnInit } from '@angular/core';
import { BaseFormDetailComponent } from '../../base/base-form-detail.component';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { InsuranceService } from 'src/app/services/insurance.service';
import { Insurance } from 'src/app/classes/insurance/insurance';
import { ActivatedRoute, Router } from '@angular/router';
import { DatepickerConverterService } from 'src/app/shared/datepicker/datepicker-converter.service';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { ModalService } from 'src/app/shared/modal/modal.service';
import { timeSpanValidator } from 'src/app/shared/validators/validators';

@Component({
  selector: 'app-insurance-detail',
  templateUrl: './insurance-detail.component.html',
  styleUrls: ['./insurance-detail.component.scss']
})
export class InsuranceDetailComponent extends BaseFormDetailComponent {
  insurance: Insurance;
  vehicle: Vehicle;
  form = new FormGroup(
    {
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      cost: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]*$')
      ]),
      insurer: new FormControl('', Validators.required),
      insuranceId: new FormControl('', Validators.required),
      mileage: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]*$')
      ])
    },
    { validators: timeSpanValidator }
  );

  constructor(
    private insuranceService: InsuranceService,
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
      this.insuranceService.getById(id).subscribe(insurance => {
        this.insurance = insurance;
        this.insurance.startDate = new Date(insurance.startDate);
        this.insurance.endDate = new Date(insurance.endDate);
        this.vehicleService
          .getById(this.insurance.vehicleId)
          .subscribe(vehicle => {
            this.vehicle = vehicle;
            this.setUpForm();
          });
      });
    } else {
      this.insurance = new Insurance(0);
      this.insurance.vehicleId = +this.route.snapshot.paramMap.get('vehicleId');
      this.insurance.startDate = new Date();
      this.insurance.endDate = this.datePickerConverter.addDays(new Date(), 1);
      this.insurance.cost = 0;
      this.vehicleService
        .getById(this.insurance.vehicleId)
        .subscribe(vehicle => {
          this.vehicle = vehicle;
          this.insurance.mileage = vehicle.mileage;
          this.setUpForm();
        });
    }
  }

  setUpForm() {
    this.form.patchValue({
      cost: this.insurance.cost,
      insurer: this.insurance.insurer,
      insuranceId: this.insurance.insuranceId,
      mileage: this.insurance.mileage,
      startDate: this.insurance.startDate,
      endDate: this.insurance.endDate
    });
  }

  readForm() {
    this.insurance.cost = this.form.get('cost').value;
    this.insurance.insurer = this.form.get('insurer').value;
    this.insurance.insuranceId = this.form.get('insuranceId').value;
    this.insurance.mileage = this.form.get('mileage').value;
    this.insurance.startDate = this.form.get('startDate').value;
    this.insurance.endDate = this.form.get('endDate').value;
  }

  onSubmit() {
    this.readForm();
    if (this.insurance.id != 0) {
      this.insuranceService
        .update(this.insurance, this.insurance.id)
        .subscribe(response => {
          if (response['status'] == 200) {
            this.modalService.showSuccessModal('Insurance has been updated.');
          } else {
            this.modalService.showErrorModal('Insurance update has failed.');
          }
        });
    } else {
      this.insuranceService.create(this.insurance).subscribe(id => {
        if (id != null) {
          this.modalService.showSuccessModal('Insurance has been created.');
          this.router.navigate([
            `/vehicles/${this.insurance.vehicleId}/insurances/${id}`
          ]);
        } else {
          this.modalService.showSuccessModal('Insurance creation has failed.');
        }
      });
    }
  }

  onDelete() {
    this.modalService
      .showConfirmModal('Do you want to delete this insurance?')
      .then(confirmed => {
        if (confirmed == 'true') {
          this.insuranceService
            .delete(this.insurance.id)
            .subscribe(response => {
              if (response['status'] == 200) {
                this.modalService.showSuccessModal(
                  'Insurance has been deleted.'
                );
                this.router.navigate([`/vehicles/${this.insurance.vehicleId}`]);
              } else {
                this.modalService.showErrorModal(
                  'Insurance deletion has failed.'
                );
              }
            });
        }
      });
  }
}
