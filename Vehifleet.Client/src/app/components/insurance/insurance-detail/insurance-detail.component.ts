import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base/base.component';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { InsuranceService } from 'src/app/services/insurance.service';
import { Insurance } from 'src/app/classes/insurance/insurance';
import { ActivatedRoute } from '@angular/router';
import { DatepickerConverterService } from 'src/app/utility/datepicker/datepicker-converter.service';
import { VehicleService } from 'src/app/services/vehicle.service';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';

@Component({
  selector: 'app-insurance-detail',
  templateUrl: './insurance-detail.component.html',
  styleUrls: ['./insurance-detail.component.scss']
})
export class InsuranceDetailComponent extends BaseComponent {
  insurance: Insurance;
  vehicle: Vehicle;
  form = new FormGroup({
    startDate: new FormControl('', Validators.required),
    endDate: new FormControl('', Validators.required),
    cost: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]*$')
    ]),
    insurer: new FormControl('', Validators.required),
    insuranceId: new FormControl('', Validators.required),
    mileage: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]*$')
    ])
  });

  constructor(
    private insuranceService: InsuranceService,
    private datePickerConverter: DatepickerConverterService,
    private vehicleService: VehicleService,
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
      this.insurance = new Insurance();
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

  submit() {
    throw new Error('Method not implemented.');
  }
}
