import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { Booking } from 'src/app/classes/booking/booking';
import { BookingListItem } from 'src/app/classes/booking/booking-list-item';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.scss']
})
export class BookingListComponent implements OnInit {
  // List of bookings; clicking a booking routes to booking-detail.
  bookings: BookingListItem[];

  constructor(private bookingService: BookingService, private router: Router) {}

  ngOnInit() {
    this.getBookings();
  }

  getBookings() {
    this.bookingService.get().subscribe(bookings => (this.bookings = bookings));
  }

  selectBooking(id: number) {
    this.router.navigate([`/bookings/${id}`]);
  }
}
