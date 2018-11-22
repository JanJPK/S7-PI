import { Component, OnInit } from '@angular/core';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';
import { VehicleModel } from 'src/app/classes/vehicle-model/vehicle-model';

@Component({
  selector: 'app-vehicle-model-list',
  templateUrl: './vehicle-model-list.component.html',
  styleUrls: ['./vehicle-model-list.component.scss']
})
export class VehicleModelListComponent implements OnInit {
  vehicleModels: VehicleModel[];

  constructor(private vehicleModelService: VehicleModelService) {}

  ngOnInit() {
    this.vehicleModelService.get().subscribe(vehicleModels => {
      this.vehicleModels = vehicleModels;
      console.log(vehicleModels);
    });
  }
}
