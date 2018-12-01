import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { VehicleModelService } from 'src/app/services/vehicle-model.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';

@Component({
  selector: 'app-vehicle-list-filter',
  templateUrl: './vehicle-list-filter.component.html',
  styleUrls: ['./vehicle-list-filter.component.scss']
})
export class VehicleListFilterComponent implements OnInit {
  @Output() filterEvent = new EventEmitter<VehicleListFilter>();
  manufacturer: string;
  locationCode: string;
  minBookingDays: number;

  form = new FormGroup({
    manufacturer: new FormControl(''),
    locationCode: new FormControl(''),
    minBookingDays: new FormControl('', Validators.pattern('^[1-9][0-9]*$'))
  });

  constructor(private vehicleModelService: VehicleModelService) {}

  ngOnInit() {}

  onFilter() {
    let filter = new VehicleListFilter();
    filter.manufacturer = this.form.get('manufacturer').value;
    filter.locationCode = this.form.get('locationCode').value;
    filter.minBookingDays = this.form.get('minBookingDays').value;
    this.filterEvent.emit(filter);
  }

  onReset() {
    this.filterEvent.emit(null);
  }

  isInvalid(formControlName: string): boolean {
    const formControl = this.form.get(formControlName);
    return !formControl.valid && (formControl.touched || formControl.dirty);
  }
}
