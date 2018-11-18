import { TestBed } from '@angular/core/testing';

import { BookingService } from './booking.service';

describe('BookingServicee', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BookingService = TestBed.get(BookingService);
    expect(service).toBeTruthy();
  });
});
