import { Component, OnInit } from '@angular/core';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';
import { ActivatedRoute } from '@angular/router';
import { VehicleModel } from 'src/app/classes/vehicle-model/vehicle-model';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-vehicle-model-detail',
  templateUrl: './vehicle-model-detail.component.html',
  styleUrls: ['./vehicle-model-detail.component.scss']
})
export class VehicleModelDetailComponent implements OnInit {
  constructor(
    private vehicleModelService: VehicleModelService,
    private route: ActivatedRoute
  ) {}

  vehicleModel: VehicleModel;
  vehicleModelForm = new FormGroup({
    manufacturer: new FormControl('', Validators.required),
    model: new FormControl('', Validators.required),
    configurationCode: new FormControl('', Validators.required),
    engine: new FormControl('', Validators.required),
    horsepower: new FormControl('', Validators.required),
    seats: new FormControl('', Validators.required),
    weight: new FormControl('', Validators.required)
  });

  ngOnInit() {
    this.getVehicleModel();
  }

  getVehicleModel() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id != 0) {
      this.vehicleModelService.getById(id).subscribe(vehicleModel => {
        this.vehicleModel = vehicleModel;
        this.setUpForm();
      });
    } else {
      this.vehicleModel = new VehicleModel();
    }
  }

  setUpForm() {
    this.vehicleModelForm.patchValue({
      manufacturer: this.vehicleModel.manufacturer,
      model: this.vehicleModel.model,
      configurationCode: this.vehicleModel.configurationCode,
      engine: this.vehicleModel.engine,
      horsepower: this.vehicleModel.horsepower,
      seats: this.vehicleModel.seats,
      weight: this.vehicleModel.weight
    });
  }
}
