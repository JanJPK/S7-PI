import { Component, OnInit } from '@angular/core';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';
import { ActivatedRoute } from '@angular/router';
import { VehicleModel } from 'src/app/classes/vehicle-model/vehicle-model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BaseComponent } from 'src/app/components/base/base.component';

@Component({
  selector: 'app-vehicle-model-detail',
  templateUrl: './vehicle-model-detail.component.html',
  styleUrls: ['./vehicle-model-detail.component.scss']
})
export class VehicleModelDetailComponent extends BaseComponent {
  vehicleModel: VehicleModel;
  form = new FormGroup({
    manufacturer: new FormControl('', Validators.required),
    model: new FormControl('', Validators.required),
    configurationCode: new FormControl('', Validators.required),
    engine: new FormControl('', Validators.required),
    horsepower: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]*$')
    ]),
    seats: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]*$')
    ]),
    weight: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]*$')
    ])
  });

  get newEntity(): boolean {
    return this.vehicleModel.id == 0;
  }

  constructor(
    private vehicleModelService: VehicleModelService,
    private route: ActivatedRoute
  ) {
    super();
  }

  get() {
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
    this.form.patchValue({
      manufacturer: this.vehicleModel.manufacturer,
      model: this.vehicleModel.model,
      configurationCode: this.vehicleModel.configurationCode,
      engine: this.vehicleModel.engine,
      horsepower: this.vehicleModel.horsepower,
      seats: this.vehicleModel.seats,
      weight: this.vehicleModel.weight
    });
  }

  onSubmit() {
    throw new Error('Method not implemented.');
  }
}
