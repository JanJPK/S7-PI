import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../../services/vehicle.service';
import { VehicleListItem } from '../../../classes/vehicle-list-item';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss']
})
export class VehicleListComponent implements OnInit {
  vehicles: VehicleListItem[];

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.getBookableVehicles();
  }

  getBookableVehicles() {
    this.vehicleService.getBookableVehicles()
    .subscribe(vehicles => this.vehicles = vehicles);
  }

}
