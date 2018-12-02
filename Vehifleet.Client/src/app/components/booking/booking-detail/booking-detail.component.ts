import { Component, OnInit } from '@angular/core';
import { Booking } from 'src/app/classes/booking/booking';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { timeSpanValidator } from 'src/app/shared/validators/validators';
import { ActivatedRoute, Router } from '@angular/router';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';
import { BookingService } from 'src/app/services/booking.service';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DatepickerConverterService } from 'src/app/shared/datepicker/datepicker-converter.service';
import { UserService } from 'src/app/shared/user/user.service';
import { BaseFormComponent } from 'src/app/components/base/base-form.component';
import { ModalService } from 'src/app/shared/modal/modal.service';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.scss']
})
export class BookingDetailComponent extends BaseFormComponent {
  vehicle: Vehicle;
  booking: Booking;
  form = new FormGroup(
    {
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      status: new FormControl(''),
      purpose: new FormControl('', Validators.required),
      notes: new FormControl(''),
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
    },
    { validators: timeSpanValidator }
  );
  startDateMin: NgbDateStruct;
  startDateMax: NgbDateStruct;
  endDateMin: NgbDateStruct;
  endDateMax: NgbDateStruct;

  get newEntity(): boolean {
    return this.vehicle.id == 0;
  }

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService,
    private vehicleService: VehicleService,
    private userService: UserService,
    private modalService: ModalService,
    private router: Router,
    private datepickerConverter: DatepickerConverterService
  ) {
    super();
  }

  get() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id != 0) {
      this.bookingService.getById(id).subscribe(booking => {
        this.booking = booking;
        this.booking.startDate = new Date(booking.startDate);
        this.booking.endDate = new Date(booking.endDate);
        this.vehicleService
          .getById(this.booking.vehicleId)
          .subscribe(vehicle => {
            this.vehicle = vehicle;
            this.setUpForm();
          });
      });
    } else {
      this.booking = new Booking();
      this.booking.id = 0;
      this.booking.status = 'Created';
      this.booking.startDate = new Date();
      this.booking.endDate = this.datepickerConverter.addDays(new Date(), 2);
      const vehicleId = +this.route.snapshot.paramMap.get('vehicleId');
      this.vehicleService.getById(vehicleId).subscribe(vehicle => {
        this.vehicle = vehicle;
        this.setUpForm();
      });
    }
  }

  setUpForm() {
    this.form.patchValue({
      startDate: this.booking.startDate,
      endDate: this.booking.endDate,
      status: this.booking.status,
      purpose: this.booking.purpose,
      notes: this.booking.notes,
      cost: this.booking.cost,
      fuelConsumed: this.booking.fuelConsumed,
      mileage: this.booking.mileage
    });
    this.setUpDatepicker();
    switch (this.booking.status) {
      case 'Submitted': {
        this.form.get('startDate').disable();
        this.form.get('endDate').disable();
        this.form.get('purpose').disable();
      }
      case 'Accepted': {
        this.form.get('startDate').disable();
        this.form.get('endDate').disable();
        this.form.get('purpose').disable();
      }
      case 'Rejected': {
        this.form.disable();
      }
      case 'Completed': {
        if (
          !(
            this.userService.isElevatedUser() ||
            this.userService.getEmployee().id != this.booking.employeeId
          )
        ) {
          this.form.disable();
        }
      }
    }
    if (this.booking.status == 'Rejected') {
    } else if (
      this.booking.status != 'Created' &&
      this.booking.status != 'Submitted'
    ) {
      this.form.get('startDate').disable();
      this.form.get('endDate').disable();
    }
  }

  setUpDatepicker() {
    this.startDateMin = this.datepickerConverter.dateToNgbDate(new Date());
    this.startDateMax = this.datepickerConverter.dateToNgbDate(
      this.datepickerConverter.addDays(new Date(), 7)
    );
    this.endDateMin = this.datepickerConverter.dateToNgbDate(
      this.datepickerConverter.addDays(new Date(), 1)
    );
    let endDateMax = this.datepickerConverter.addDays(
      this.vehicle.canBeBookedUntil,
      -1
    );
    if (endDateMax.getDay() == 0) {
      endDateMax = this.datepickerConverter.addDays(endDateMax, 1);
    } else if (endDateMax.getDay() == 6) {
      endDateMax = this.datepickerConverter.addDays(endDateMax, -1);
    }
    this.endDateMax = this.datepickerConverter.dateToNgbDate(endDateMax);
  }

  canBeEdited(status: string): boolean {
    if (status == 'Created' || status == 'Accepted') {
      // Employees can edit their unsubmitted and accepted (ongoing) bookings.
      return this.userService.getEmployee().id == this.booking.employeeId;
    } else if (status == 'Submitted' || status == 'Completed') {
      // Managers can edit submitted and completed bookings,
      // unless they are the ones who created them.
      return (
        this.userService.isElevatedUser() &&
        this.userService.getEmployee().id != this.booking.employeeId
      );
    } else {
      return false;
    }
  }

  isCurrentStatus(status: string): boolean {
    return status == this.booking.status;
  }

  onChangeStatus(status: string) {
    switch (status) {
      case 'Submitted': {
        this.modalService
          .showConfirmModal(
            'Do you want to submit this booking? Submitted booking cannot be edited.'
          )
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = status;
              this.onSubmit();
            }
          });
      }
      case 'Accepted': {
        this.modalService
          .showConfirmModal('Do you want to accept this booking?')
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = status;
              this.onSubmit();
            }
          });
      }
      case 'Rejected': {
        this.modalService
          .showConfirmModal('Do you want to reject this booking?')
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = status;
              this.onSubmit();
            }
          });
      }
      case 'Completed': {
        this.modalService
          .showConfirmModal(
            'Do you want to complete this booking? Completed booking cannot be edited.'
          )
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = status;
              this.onSubmit();
            }
          });
      }
    }
  }

  readForm() {
    this.booking.startDate = this.form.get('startDate').value;
    this.booking.endDate = this.form.get('endDate').value;
    this.booking.status = this.form.get('status').value;
    this.booking.purpose = this.form.get('purpose').value;
    this.booking.notes = this.form.get('notes').value;
    this.booking.cost = this.form.get('cost').value;
  }

  onSubmit() {
    this.readForm();
    if (this.booking.id != 0) {
      this.bookingService
        .update(this.booking, this.booking.id)
        .subscribe(response => {
          if (response['status'] == 200) {
            this.modalService.showSuccessModal('Boking has been updated.');
          } else {
            this.modalService.showErrorModal('Boking update has failed.');
          }
        });
    } else {
      this.bookingService.create(this.booking).subscribe(id => {
        if (id != null) {
          this.modalService.showSuccessModal('Boking has been created.');
          this.router.navigate([`/vehicles/bookings/${id}`]);
        } else {
          this.modalService.showSuccessModal('Boking creation has failed.');
        }
      });
    }
  }

  onDelete() {
    this.modalService
      .showConfirmModal('Do you want to delete this booking?')
      .then(confirmed => {
        if (confirmed == 'true') {
          this.bookingService.delete(this.booking.id).subscribe(response => {
            if (response['status'] == 200) {
              this.modalService.showSuccessModal('Booking has been deleted.');
              this.router.navigate([`/bookings`]);
            } else {
              this.modalService.showErrorModal('Booking deletion has failed.');
            }
          });
        }
      });
  }
}
