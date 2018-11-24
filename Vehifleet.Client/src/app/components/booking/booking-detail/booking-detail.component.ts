import { Component, OnInit } from '@angular/core';
import { Booking } from 'src/app/classes/booking/booking';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { timeSpanValidator } from 'src/app/utility/validators';
import { ActivatedRoute } from '@angular/router';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';
import { BookingService } from 'src/app/services/booking.service';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DatepickerConverterService } from 'src/app/utility/datepicker/datepicker-converter.service';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.scss']
})
export class BookingDetailComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService,
    private vehicleService: VehicleService,
    private datepickerConverter: DatepickerConverterService
  ) {}

  vehicle: Vehicle;
  booking: Booking;
  bookingForm = new FormGroup(
    {
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      status: new FormControl(''),
      purpose: new FormControl('', Validators.required),
      notes: new FormControl('')
    },
    { validators: timeSpanValidator }
  );
  isNewBooking: boolean;
  startDateMin: NgbDateStruct;
  startDateMax: NgbDateStruct;
  endDateMin: NgbDateStruct;
  endDateMax: NgbDateStruct;

  ngOnInit() {
    this.getBooking();
  }

  getBooking() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id != 0) {
      // Loading booking
      this.isNewBooking = false;
      this.bookingService.getById(id).subscribe(booking => {
        this.booking = booking;
        this.vehicleService
          .getById(this.booking.vehicleId)
          .subscribe(vehicle => {
            this.vehicle = vehicle;
            this.setUpForm();
          });
      });
    } else {
      // Creating new booking
      this.isNewBooking = true;
      this.booking = new Booking();
      this.booking.status = 'Created';
      this.booking.startDate = new Date();
      this.booking.endDate = this.datepickerConverter.addDays(new Date(), 2);
      const vehicleId = +this.route.snapshot.paramMap.get('vehicleId');
      this.vehicleService.getById(vehicleId).subscribe(vehicle => {
        this.vehicle = vehicle;
        this.setUpForm();
      });
    }
  }

  setUpForm() {
    this.bookingForm.patchValue({
      startDate: this.booking.startDate,
      endDate: this.booking.endDate,
      status: this.booking.status,
      purpose: this.booking.purpose,
      notes: this.booking.notes
    });
    this.setUpDatepicker();
  }

  setUpDatepicker() {
    this.startDateMin = this.datepickerConverter.dateToNgbDate(new Date());
    this.startDateMax = this.datepickerConverter.dateToNgbDate(
      this.datepickerConverter.addDays(new Date(), 7)
    );
    this.endDateMin = this.datepickerConverter.dateToNgbDate(
      this.datepickerConverter.addDays(new Date(), 1)
    );
    let endDateMax = this.datepickerConverter.addDays(
      this.vehicle.canBeBookedUntil,
      -1
    );
    if (endDateMax.getDay() == 0) {
      endDateMax = this.datepickerConverter.addDays(endDateMax, 1);
    } else if (endDateMax.getDay() == 6) {
      endDateMax = this.datepickerConverter.addDays(endDateMax, -1);
    }
    this.endDateMax = this.datepickerConverter.dateToNgbDate(endDateMax);
  }

  isCurrentStatus(status: string): boolean {
    return this.booking.status == status;
  }

  submit() {
    this.booking.startDate = new Date(this.bookingForm.get('startDate').value);
    this.booking.endDate = new Date(this.bookingForm.get('endDate').value);
    let bookingId: number;
    this.bookingService.create(this.booking).subscribe(id => (bookingId = id));
  }
}
