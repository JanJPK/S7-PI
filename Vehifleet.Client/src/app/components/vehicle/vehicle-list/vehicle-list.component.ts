import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { VehicleService } from '../../../services/vehicle.service';
import { VehicleListItem } from '../../../classes/vehicle-list-item';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss']
})
export class VehicleListComponent implements OnInit {
  vehicles: VehicleListItem[];

  @Output() vehicleClicked = new EventEmitter<number>();

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.getBookableVehicles();
  }

  selectVehicle(id: number) {
    console.log(id);
    this.vehicleClicked.emit(id);
  }

  getBookableVehicles() {
    this.vehicleService.getBookableVehicles()
    .subscribe(vehicles => this.vehicles = vehicles);
  }

}
