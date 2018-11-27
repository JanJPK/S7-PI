import { Component, OnInit } from '@angular/core';
import { Booking } from 'src/app/classes/booking/booking';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { timeSpanValidator } from 'src/app/shared/validators/validators';
import { ActivatedRoute } from '@angular/router';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';
import { BookingService } from 'src/app/services/booking.service';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DatepickerConverterService } from 'src/app/shared/datepicker/datepicker-converter.service';
import { UserService } from 'src/app/shared/user/user.service';
import { BaseComponent } from 'src/app/components/base/base.component';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.scss']
})
export class BookingDetailComponent extends BaseComponent {
  vehicle: Vehicle;
  booking: Booking;
  form = new FormGroup(
    {
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      status: new FormControl(''),
      purpose: new FormControl('', Validators.required),
      notes: new FormControl('')
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
      notes: this.booking.notes
    });
    this.setUpDatepicker();
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

  onSubmit() {
    this.booking.startDate = new Date(this.form.get('startDate').value);
    this.booking.endDate = new Date(this.form.get('endDate').value);
    let bookingId: number;
    //this.bookingService.create(this.booking).subscribe(id => (bookingId = id));
  }
}
