import { Component, OnInit } from '@angular/core';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';
import { VehicleModel } from 'src/app/classes/vehicle-model/vehicle-model';
import { Router } from '@angular/router';
import { VehicleModelListFilter } from 'src/app/classes/vehicle-model/vehicle-model-list-filter';

@Component({
  selector: 'app-vehicle-model-list',
  templateUrl: './vehicle-model-list.component.html',
  styleUrls: ['./vehicle-model-list.component.scss']
})
export class VehicleModelListComponent implements OnInit {
  vehicleModels: VehicleModel[];

  constructor(
    private vehicleModelService: VehicleModelService,
    private router: Router
  ) {}

  ngOnInit() {
    this.get();
  }

  get(filter?: VehicleModelListFilter) {
    this.vehicleModelService.get(filter).subscribe(vehicleModels => {
      this.vehicleModels = vehicleModels;
    });
  }

  select(id: number) {
    this.router.navigate([`/vehicle-models/${id}`]);
  }
}
