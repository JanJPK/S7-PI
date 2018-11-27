import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-list-booking-details',
  templateUrl: './vehicle-list-booking-details.component.html',
  styleUrls: ['./vehicle-list-booking-details.component.scss']
})
export class VehicleListBookingDetailsComponent implements OnInit {
  @Input()
  set selectedVehicle(selectedVehicle: Vehicle) {
    this.vehicle = selectedVehicle;
  }

  vehicle: Vehicle;
  startDateMin: NgbDateStruct;
  startDateMax: NgbDateStruct;
  endDateMin: NgbDateStruct;
  endDateMax: NgbDateStruct;
  constructor(private router: Router) {}

  ngOnInit() {}

  newBooking() {
    this.router.navigate(['/bookings/0', { vehicleId: this.vehicle.id }]);
  }
}
