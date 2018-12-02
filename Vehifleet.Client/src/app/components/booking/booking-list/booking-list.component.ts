import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { BookingListItem } from 'src/app/classes/booking/booking-list-item';
import { BookingListFilter } from 'src/app/classes/booking/booking-list-filter';
import { DatepickerConverterService } from 'src/app/shared/datepicker/datepicker-converter.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.scss']
})
export class BookingListComponent implements OnInit {
  // List of bookings; clicking a booking routes to booking-detail.
  bookings: BookingListItem[];

  constructor(
    private bookingService: BookingService,
    private dateConverter: DatepickerConverterService,
    private router: Router
  ) {}

  ngOnInit() {
    let filter = new BookingListFilter();
    filter.statuses = ['Accepted', 'Submitted', 'Completed'];
    filter.fromDate = this.dateConverter.addDays(new Date(), -90).toJSON();
    this.get(filter);
  }

  get(filter?: BookingListFilter) {
    this.bookingService
      .get(filter)
      .subscribe(bookings => (this.bookings = bookings));
  }

  select(id: number) {
    this.router.navigate([`/bookings/${id}`]);
  }
}
