import { Component, OnInit } from '@angular/core';
import { VehicleService } from 'src/app/services/vehicle.service';
import { VehicleListItem } from 'src/app/classes/vehicle/vehicle-list-item';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';

@Component({
  selector: 'app-vehicle-list-booking',
  templateUrl: './vehicle-list-booking.component.html',
  styleUrls: ['./vehicle-list-booking.component.scss']
})
export class VehicleListBookingComponent implements OnInit {
  vehicles: VehicleListItem[];
  selectedVehicle: Vehicle;

  constructor(private vehicleService: VehicleService) {}

  ngOnInit() {
    this.get();
  }

  get(filter?: VehicleListFilter) {
    if (filter == null) {
      filter = new VehicleListFilter();
      filter.minBookingDays = 1;
    }
    filter.status = 'Available';
    console.log(filter);
    this.vehicleService
      .get(filter)
      .subscribe(vehicles => (this.vehicles = vehicles));
  }

  select(id: number) {
    this.vehicleService
      .getById(id)
      .subscribe(vehicle => (this.selectedVehicle = vehicle));
  }
}
