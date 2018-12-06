import { Component, OnInit } from '@angular/core';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleModel } from 'src/app/classes/vehicle-model/vehicle-model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BaseFormDetailComponent } from '../../base/base-form-detail.component';
import { ModalService } from 'src/app/shared/modal/modal.service';

@Component({
  selector: 'app-vehicle-model-detail',
  templateUrl: './vehicle-model-detail.component.html',
  styleUrls: ['./vehicle-model-detail.component.scss']
})
export class VehicleModelDetailComponent extends BaseFormDetailComponent {
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
      Validators.pattern('^[0-9]*$')
    ]),
    purchaseCost: new FormControl('', [
      Validators.required,
      Validators.pattern('^[1-9][0-9]*$')
    ]),
    mileage: new FormControl(''),
    fuelConsumed: new FormControl(''),
    cost: new FormControl('')
  });

  constructor(
    private vehicleModelService: VehicleModelService,
    private modalService: ModalService,
    private router: Router,
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
      this.vehicleModel = new VehicleModel(0);
    }
  }

  setUpForm() {
    this.form.patchValue({
      manufacturer: this.vehicleModel.manufacturer,
      model: this.vehicleModel.model,
      configurationCode: this.vehicleModel.configurationCode,
      purchaseCost: this.vehicleModel.purchaseCost,
      engine: this.vehicleModel.engine,
      horsepower: this.vehicleModel.horsepower,
      seats: this.vehicleModel.seats,
      weight: this.vehicleModel.weight
    });
  }

  readForm() {
    this.vehicleModel.manufacturer = this.form.get('manufacturer').value;
    this.vehicleModel.model = this.form.get('model').value;
    this.vehicleModel.configurationCode = this.form.get(
      'configurationCode'
    ).value;
    this.vehicleModel.purchaseCost = this.form.get('purchaseCost').value;
    this.vehicleModel.engine = this.form.get('engine').value;
    this.vehicleModel.horsepower = this.form.get('horsepower').value;
    this.vehicleModel.seats = this.form.get('seats').value;
    this.vehicleModel.weight = this.form.get('weight').value;
  }

  onSubmit() {
    this.readForm();
    console.log(this.vehicleModel.id);
    if (this.vehicleModel.id != 0) {
      this.vehicleModelService
        .update(this.vehicleModel, this.vehicleModel.id)
        .subscribe(response => {
          if (response['status'] == 200) {
            this.modalService.showSuccessModal(
              'Vehicle model has been updated.'
            );
          } else {
            this.modalService.showErrorModal(
              'Vehicle model update has failed.'
            );
          }
        });
    } else {
      this.vehicleModelService.create(this.vehicleModel).subscribe(id => {
        if (id != null) {
          this.modalService.showSuccessModal('Vehicle model has been created.');
          this.router.navigate([`/vehicle-models/${id}`]);
        } else {
          this.modalService.showSuccessModal(
            'Vehicle model creation has failed.'
          );
        }
      });
    }
  }

  onDelete() {
    this.modalService
      .showConfirmModal('Do you want to delete this vehicle model?')
      .then(confirmed => {
        if (confirmed == 'true') {
          this.vehicleModelService
            .delete(this.vehicleModel.id)
            .subscribe(response => {
              if (response['status'] == 200) {
                this.modalService.showSuccessModal(
                  'Vehicle model has been deleted.'
                );
                this.router.navigate([`/vehicle-models`]);
              } else {
                this.modalService.showErrorModal(
                  'Vehicle model deletion has failed.'
                );
              }
            });
        }
      });
  }
}
