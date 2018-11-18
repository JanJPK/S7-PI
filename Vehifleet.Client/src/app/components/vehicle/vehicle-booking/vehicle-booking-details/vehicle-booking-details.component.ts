import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { FormControl, FormGroup } from '@angular/forms';
import { Booking } from 'src/app/classes/booking/booking';
import { UserService } from 'src/app/utility/user.service';
import { NgbDate, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DatepickerConverterService } from 'src/app/utility/datepicker/datepicker-converter.service';

@Component({
  selector: 'app-vehicle-booking-details',
  templateUrl: './vehicle-booking-details.component.html',
  styleUrls: ['./vehicle-booking-details.component.scss']
})
export class VehicleBookingDetailsComponent implements OnInit {
  vehicle: Vehicle;
  @Input()
  set selectedVehicle(selectedVehicle: Vehicle) {
    this.vehicle = selectedVehicle;
    this.booking = new Booking();
    this.setUpDatepicker();
  }

  booking: Booking;
  bookingForm = new FormGroup({
    startDate: new FormControl(''),
    endDate: new FormControl('')
  });
  startDateMin: NgbDateStruct;
  startDateMax: NgbDateStruct;
  endDateMin: NgbDateStruct;
  endDateMax: NgbDateStruct;
  constructor(
    private userService: UserService,
    private datepickerConverter: DatepickerConverterService
  ) {}

  ngOnInit() {
    this.booking.employeeId = this.userService.getEmployee()['id'];
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
