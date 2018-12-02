import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user/user.service';
import { BookingService } from 'src/app/services/booking.service';
import { BookingListFilter } from 'src/app/classes/booking/booking-list-filter';
import { BookingListItem } from 'src/app/classes/booking/booking-list-item';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-list-personal',
  templateUrl: './booking-list-personal.component.html',
  styleUrls: ['./booking-list-personal.component.scss']
})
export class BookingListPersonalComponent implements OnInit {
  // List of bookings created by active user; clicking a booking routes to booking-detail.
  bookings: BookingListItem[];

  constructor(
    private userService: UserService,
    private bookingService: BookingService,
    private router: Router
  ) {}

  ngOnInit() {
    this.get();
  }

  get() {
    const filter = new BookingListFilter();
    filter.employeeId = this.userService.getEmployee().id;
    this.bookingService
      .get(filter)
      .subscribe(bookings => (this.bookings = bookings));
  }

  select(id: number) {
    this.router.navigate([`/bookings/${id}`]);
  }
}
