import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BaseFormComponent } from '../../base/base-form.component';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-vehicle-list-booking-filter',
  templateUrl: './vehicle-list-booking-filter.component.html',
  styleUrls: ['./vehicle-list-booking-filter.component.scss']
})
export class VehicleListBookingFilterComponent extends BaseFormComponent {
  @Output() filterEvent = new EventEmitter<VehicleListFilter>();

  form = new FormGroup({
    manufacturer: new FormControl(''),
    locationCode: new FormControl(''),
    minBookingDays: new FormControl('', Validators.pattern('^[1-9][0-9]*$'))
  });

  constructor() {
    super();
  }

  onFilter() {
    let filter = new VehicleListFilter();
    filter.manufacturer = this.form.get('manufacturer').value;
    filter.locationCode = this.form.get('locationCode').value;
    filter.minBookingDays = this.form.get('minBookingDays').value;
    this.filterEvent.emit(filter);
  }

  onReset() {
    this.filterEvent.emit(null);
    this.form.patchValue({
      manufacturer: '',
      locationCode: '',
      minBookingDays: ''
    });
  }
}
