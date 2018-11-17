import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { FormControl, FormGroup } from '@angular/forms';
import { Booking } from 'src/app/classes/booking/booking';
import { UserService } from 'src/app/utility/user.service';
import { NgbDate, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-vehicle-booking-details',
  templateUrl: './vehicle-booking-details.component.html',
  styleUrls: ['./vehicle-booking-details.component.scss']
})
export class VehicleBookingDetailsComponent implements OnInit {
  @Input() selectedVehicle: Vehicle;
  // startDateMin: NgbDateStruct;
  // startDateMax: NgbDateStruct;
  // endDateMin: NgbDateStruct;
  // endDateMax: NgbDateStruct;
  startDateMin: Date;
  startDateMax: Date;
  endDateMin: Date;
  endDateMax: Date;
  booking: Booking;
  bookingForm = new FormGroup({
    startDate: new FormControl(''),
    endDate: new FormControl('')
  });

  constructor(private userService: UserService) {}

  ngOnInit() {
    const today = new Date();
    this.startDateMin = this.addDays(today, 7);
    this.startDateMax = this.addDays(today, 7);
    this.endDateMin = this.addDays(today, 1);
    this.endDateMax =
      this.selectedVehicle.inspectionExpirationDate <
      this.selectedVehicle.insuranceExpirationDate
        ? new Date(this.selectedVehicle.inspectionExpirationDate)
        : new Date(this.selectedVehicle.insuranceExpirationDate);
    if (this.endDateMax.getDay() == 0) {
      this.endDateMax = this.addDays(this.endDateMax, 1);
    } else if (this.endDateMax.getDay() == 6) {
      this.endDateMax = this.addDays(this.endDateMax, -1);
    }
    // const today = new Date();
    // let startDateMin = this.addDays(today, 7);
    // this.startDateMin = {
    //   year: startDateMin.getUTCFullYear(),
    //   month: startDateMin.getUTCMonth(),
    //   day: startDateMin.getUTCDay()
    // };
    // const startDayMax = this.addDays(today, 7);
    // this.startDateMax = {
    //   year: startDayMax.getUTCFullYear(),
    //   month: startDayMax.getUTCMonth(),
    //   day: startDayMax.getUTCDay()
    // };
    // const endDateMin = this.addDays(today, 1);
    // this.endDateMin = {
    //   year: endDateMin.getUTCFullYear(),
    //   month: endDateMin.getUTCMonth(),
    //   day: endDateMin.getUTCDay()
    // };
    // let endDateMax =
    //   this.selectedVehicle.inspectionExpirationDate <
    //   this.selectedVehicle.insuranceExpirationDate
    //     ? new Date(this.selectedVehicle.inspectionExpirationDate)
    //     : new Date(this.selectedVehicle.insuranceExpirationDate);
    // if (endDateMax.getDay() == 0) {
    //   endDateMax = this.addDays(endDateMax, 1);
    // } else if (endDateMax.getDay() == 6) {
    //   endDateMax = this.addDays(endDateMax, -1);
    // }
    // this.endDateMax = {
    //   year: endDateMax.getUTCFullYear(),
    //   month: endDateMax.getUTCMonth(),
    //   day: endDateMax.getUTCDay() + 1
    // };

    this.booking = new Booking();
    this.booking.employeeId = this.userService.getEmployee()['id'];

    // console.log(`start min ${startDateMin}`);
    // console.log(`start max ${startDayMax}`);
    // console.log(`end min ${endDateMin}`);
    // console.log(`end max ${endDateMax}`);
  }

  addDays(date: Date, days: number): Date {
    var newDate = new Date(date);
    newDate.setDate(newDate.getDate() + days);
    return newDate;
  }
}
