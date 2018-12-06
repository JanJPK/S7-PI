import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Booking } from '../classes/booking/booking';
import { BookingListItem } from '../classes/booking/booking-list-item';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService extends BaseService<
  Booking,
  BookingListItem,
  number
> {
  constructor(
    http: HttpClient,
    userService: UserService,
    logger: LoggerService
  ) {
    super(http, 'bookings', userService, logger);
  }
}
