import { Component, OnInit, Input } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';

@Component({
  selector: 'app-vehicle-booking-detail',
  templateUrl: './vehicle-booking-detail.component.html',
  styleUrls: ['./vehicle-booking-detail.component.scss']
})
export class VehicleBookingDetailComponent implements OnInit {
  @Input() selectedVehicle: Vehicle;

  constructor() {}

  ngOnInit() {}
}
