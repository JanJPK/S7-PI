import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';

@Component({
  selector: 'app-vehicle-booking-details',
  templateUrl: './vehicle-booking-details.component.html',
  styleUrls: ['./vehicle-booking-details.component.scss']
})
export class VehicleBookingDetailsComponent implements OnInit {
  @Input() selectedVehicle: Vehicle;

  constructor() {}

  ngOnInit() {}
}
