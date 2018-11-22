import { Component, OnInit } from '@angular/core';
import { VehicleListItem } from 'src/app/classes/vehicle/vehicle-list-item';
import { Vehicle } from 'src/app/classes/vehicle/vehicle';
import { VehicleService } from 'src/app/services/vehicle.service';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss']
})
export class VehicleListComponent implements OnInit {
  vehicles: VehicleListItem[];
  selectedVehicle: Vehicle;

  constructor(private vehicleService: VehicleService, private router: Router) {}

  ngOnInit() {
    this.getVehicles();
  }

  selectVehicle(id: number) {
    this.router.navigate([`/vehicles/${id}`]);
  }

  getVehicles() {
    this.vehicleService.get().subscribe(vehicles => (this.vehicles = vehicles));
  }
}
