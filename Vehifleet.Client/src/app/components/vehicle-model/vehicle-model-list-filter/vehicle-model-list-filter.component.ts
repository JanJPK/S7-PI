import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { VehicleModelListFilter } from 'src/app/classes/vehicle-model/vehicle-model-list-filter';
import { BaseFormComponent } from '../../base/base-form.component';

@Component({
  selector: 'app-vehicle-model-list-filter',
  templateUrl: './vehicle-model-list-filter.component.html',
  styleUrls: ['./vehicle-model-list-filter.component.scss']
})
export class VehicleModelListFilterComponent extends BaseFormComponent {
  @Output() filterEvent = new EventEmitter<VehicleModelListFilter>();

  form = new FormGroup({
    manufacturer: new FormControl('')
  });

  constructor() {
    super();
  }

  onFilter() {
    let filter = new VehicleModelListFilter();
    filter.manufacturer = this.form.get('manufacturer').value;
    this.filterEvent.emit(filter);
  }

  onReset() {
    this.filterEvent.emit(null);
    this.form.patchValue({
      manufacturer: ''
    });
  }
}
