import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/utility/user.service';
import { BookingService } from 'src/app/services/booking.service';
import { Booking } from 'src/app/classes/booking/booking';
import { BookingListFilter } from 'src/app/classes/booking/booking-list-filter';
import { BookingListItem } from 'src/app/classes/booking/booking-list-item';

@Component({
  selector: 'app-booking-personal',
  templateUrl: './booking-personal.component.html',
  styleUrls: ['./booking-personal.component.scss']
})
export class BookingPersonalComponent implements OnInit {
  bookings: BookingListItem[];

  constructor(
    private userService: UserService,
    private bookingService: BookingService
  ) {}

  ngOnInit() {
    this.getPersonalBookings();
  }

  getPersonalBookings() {
    const filter = new BookingListFilter();
    filter.employeeId = this.userService.getEmployee().id;
    this.bookingService
      .get(filter)
      .subscribe(bookings => (this.bookings = bookings));
  }
}
