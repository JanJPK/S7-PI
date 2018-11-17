import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { VehicleService } from '../../../services/vehicle.service';
import { VehicleListItem } from '../../../classes/vehicle/vehicle-list-item';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';

@Component({
  selector: 'app-vehicle-booking',
  templateUrl: './vehicle-booking.component.html',
  styleUrls: ['./vehicle-booking.component.scss']
})
export class VehicleBookingComponent implements OnInit {
  vehicles: VehicleListItem[];
  selectedVehicle: Vehicle;

  @Output() vehicleClicked = new EventEmitter<number>();

  constructor(private vehicleService: VehicleService) {}

  ngOnInit() {
    this.getBookableVehicles();
  }

  selectVehicle(id: number) {
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
