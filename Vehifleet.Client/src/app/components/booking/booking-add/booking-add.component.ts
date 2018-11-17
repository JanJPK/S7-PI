import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/utility/user.service';
import { Booking } from 'src/app/classes/booking/booking';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-booking-add',
  templateUrl: './booking-add.component.html',
  styleUrls: ['./booking-add.component.scss']
})
export class BookingAddComponent implements OnInit {
  vehicleId: number;
  employeeId: number;
  booking: Booking;
  bookingForm = new FormGroup({
    startDate: new FormControl(''),
    endDate: new FormControl('')
  });

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.booking = new Booking();
    this.booking.vehicleId = +this.route.snapshot.paramMap.get('vehicleId');
    this.booking.employeeId = this.userService.getEmployee()['id'];
    console.log(this.booking);
  }
}
