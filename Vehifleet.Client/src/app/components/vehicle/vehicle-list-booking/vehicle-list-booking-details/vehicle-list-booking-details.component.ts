import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { Validators, FormGroup, FormControl } from '@angular/forms';
import { Booking } from 'src/app/classes/booking/booking';
import { UserService } from 'src/app/utility/user.service';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DatepickerConverterService } from 'src/app/utility/datepicker/datepicker-converter.service';
import { timeSpanValidator } from 'src/app/utility/validators';
import { BookingService } from 'src/app/services/booking.service';

@Component({
  selector: 'app-vehicle-list-booking-details',
  templateUrl: './vehicle-list-booking-details.component.html',
  styleUrls: ['./vehicle-list-booking-details.component.scss']
})
export class VehicleListBookingDetailsComponent implements OnInit {
  @Input()
  set selectedVehicle(selectedVehicle: Vehicle) {
    this.vehicle = selectedVehicle;
    this.booking = new Booking();
    this.booking.vehicleId = this.vehicle.id;
    this.setUpDatepicker();
  }

  vehicle: Vehicle;
  booking: Booking;
  bookingForm = new FormGroup(
    {
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required)
    },
    { validators: timeSpanValidator }
  );
  startDateMin: NgbDateStruct;
  startDateMax: NgbDateStruct;
  endDateMin: NgbDateStruct;
  endDateMax: NgbDateStruct;
  constructor(
    private userService: UserService,
    private bookingService: BookingService,
    private datepickerConverter: DatepickerConverterService
  ) {}

  ngOnInit() {
    this.booking.employeeId = this.userService.getEmployee()['id'];
  }

  submit() {
    this.booking.startDate = new Date(this.bookingForm.get('startDate').value);
    this.booking.endDate = new Date(this.bookingForm.get('endDate').value);
    this.booking.status = 'Created';
    let bookingId: number;
    this.bookingService.create(this.booking).subscribe(id => (bookingId = id));
  }

  addDays(date: Date, days: number): Date {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() + days);
    return newDate;
  }

  setUpDatepicker() {
    this.startDateMin = this.datepickerConverter.dateToNgbDate(new Date());
    this.startDateMax = this.datepickerConverter.dateToNgbDate(
      this.addDays(new Date(), 7)
    );
    this.endDateMin = this.datepickerConverter.dateToNgbDate(
      this.addDays(new Date(), 1)
    );
    let endDateMax = this.addDays(this.vehicle.canBeBookedUntil, -1);
    if (endDateMax.getDay() == 0) {
      endDateMax = this.addDays(endDateMax, 1);
    } else if (endDateMax.getDay() == 6) {
      endDateMax = this.addDays(endDateMax, -1);
    }
    this.endDateMax = this.datepickerConverter.dateToNgbDate(endDateMax);
  }
}
