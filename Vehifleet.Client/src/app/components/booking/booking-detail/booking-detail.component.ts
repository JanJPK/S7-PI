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
import { BaseFormDetailComponent } from '../../base/base-form-detail.component';
import { Employee } from 'src/app/classes/employee/employee';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.scss']
})
export class BookingDetailComponent extends BaseFormDetailComponent {
  vehicle: Vehicle;
  booking: Booking;
  employee: Employee;
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
      this.booking = new Booking(0);
      this.booking.employeeId = this.userService.getEmployee().id;
      this.booking.status = 'Created';
      this.booking.startDate = new Date();
      this.booking.endDate = this.datepickerConverter.addDays(new Date(), 2);
      const vehicleId = +this.route.snapshot.paramMap.get('vehicleId');
      this.vehicleService.getById(vehicleId).subscribe(vehicle => {
        this.vehicle = vehicle;
        this.booking.vehicleId = vehicleId;
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

    if (this.booking.employeeId != this.userService.getEmployee().id) {
      this.userService
        .getEmployeeById(this.booking.employeeId)
        .subscribe(employee => {
          this.employee = employee;
        });
    }
    this.setUpDatepicker();

    if (!this.canBeEdited()) {
      this.form.disable();
    }

    if (this.booking.status != 'Created') {
      if (!this.canBeEdited('Submitted')) {
        this.form.get('notes').disable();
      }
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

  canBeEdited(status: string = null): boolean {
    const currentUserId = this.userService.getEmployee().id;
    const isCurrentUserElevated = this.userService.isElevatedUser();
    if (status == null) {
      status = this.booking.status;
    }
    switch (status) {
      case 'Created': {
        if (this.booking.employeeId == currentUserId) {
          return true;
        }
        break;
      }
      case 'Submitted': {
        if (this.booking.employeeId != currentUserId && isCurrentUserElevated) {
          return true;
        }
        break;
      }
      case 'Accepted': {
        if (this.booking.employeeId == currentUserId) {
          return true;
        }
        break;
      }
      case 'Rejected': {
        return false;
      }
      case 'Completed': {
        if (this.booking.employeeId != currentUserId && isCurrentUserElevated) {
          return true;
        }
        break;
      }
      default: {
        return false;
        break;
      }
    }
  }

  isCurrentStatus(status: string): boolean {
    return status == this.booking.status;
  }

  onChangeStatus(newStatus: string) {
    switch (newStatus) {
      case 'Submitted': {
        this.modalService
          .showConfirmModal(
            'Do you want to submit this booking? Submitted booking cannot be edited.'
          )
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = newStatus;
              this.form.patchValue({
                status: newStatus
              });
              this.onSubmit();
              this.form.disable();
            }
          });
        break;
      }
      case 'Accepted': {
        this.modalService
          .showConfirmModal('Do you want to accept this booking?')
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = newStatus;
              this.form.patchValue({
                status: newStatus
              });
              this.onSubmit();
            }
          });
        break;
      }
      case 'Rejected': {
        this.modalService
          .showConfirmModal('Do you want to reject this booking?')
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = newStatus;
              this.form.patchValue({
                status: newStatus
              });
              this.onSubmit();
              this.form.disable();
            }
          });
        break;
      }
      case 'Completed': {
        this.modalService
          .showConfirmModal(
            'Do you want to complete this booking? Completed booking cannot be edited.'
          )
          .then(confirmed => {
            if (confirmed == 'true') {
              this.booking.status = newStatus;
              this.form.patchValue({
                status: newStatus
              });
              this.onSubmit();
              this.form.disable();
            }
          });
        break;
      }
      default: {
        return;
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
    this.booking.mileage = this.form.get('mileage').value;
    this.booking.fuelConsumed = this.form.get('fuelConsumed').value;
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
          this.router.navigate([`/bookings/${id}`]);
          this.get();
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
