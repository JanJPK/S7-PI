import { Component, OnInit } from '@angular/core';
import { Vehicle } from 'src/app/classes/vehicle';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.scss']
})
export class VehicleComponent implements OnInit {

  selectedVehicle: Vehicle;

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
  }

  onVehicleClicked(id: number) {
    console.log(id);
    this.vehicleService.getById(id)
    .subscribe(vehicle => this.selectedVehicle = vehicle);
  }

}
