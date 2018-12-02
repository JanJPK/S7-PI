import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';
import { BaseFormComponent } from '../../base/base-form.component';

@Component({
  selector: 'app-vehicle-list-filter',
  templateUrl: './vehicle-list-filter.component.html',
  styleUrls: ['./vehicle-list-filter.component.scss']
})
export class VehicleListFilterComponent extends BaseFormComponent {
  @Output() filterEvent = new EventEmitter<VehicleListFilter>();

  form = new FormGroup({
    chassisCode: new FormControl(''),
    locationCode: new FormControl(''),
    status: new FormControl('')
  });

  constructor() {
    super();
  }

  onFilter() {
    let filter = new VehicleListFilter();
    filter.chassisCode = this.form.get('chassisCode').value;
    filter.locationCode = this.form.get('locationCode').value;
    filter.status = this.form.get('status').value;
    this.filterEvent.emit(filter);
  }

  onReset() {
    this.filterEvent.emit(null);
    this.form.patchValue({
      chassisCode: '',
      locationCode: '',
      status: ''
    });
  }
}
