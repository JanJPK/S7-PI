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
    this.getBookableVehicles();
  }

  select(id: number) {
    this.vehicleService
      .getById(id)
      .subscribe(vehicle => (this.selectedVehicle = vehicle));
  }

  getBookableVehicles() {
    const filter = new VehicleListFilter();
    filter.Status = ['Available'];
    filter.MinBookingDays = 1;
    this.vehicleService
      .get(filter)
      .subscribe(vehicles => (this.vehicles = vehicles));
  }
}
