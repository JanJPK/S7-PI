import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BaseFormComponent } from '../../base/base-form.component';
import { VehicleListFilter } from 'src/app/classes/vehicle/vehicle-list-filter';
import {
  FormGroup,
  FormControl,
  Validators,
  FormArray,
  FormBuilder
} from '@angular/forms';
import { BookingListFilter } from 'src/app/classes/booking/booking-list-filter';
import { from } from 'rxjs';

@Component({
  selector: 'app-booking-list-filter',
  templateUrl: './booking-list-filter.component.html',
  styleUrls: ['./booking-list-filter.component.scss']
})
export class BookingListFilterComponent extends BaseFormComponent {
  @Output() filterEvent = new EventEmitter<BookingListFilter>();
  statuses = [
    { name: 'Created', selected: false },
    { name: 'Submitted', selected: true },
    { name: 'Accepted', selected: true },
    { name: 'Rejected', selected: false },
    { name: 'Completed', selected: false }
  ];

  form = new FormGroup({
    employeeUserName: new FormControl(''),
    fromDate: new FormControl(''),
    toDate: new FormControl('')
  });

  constructor() {
    super();
  }

  check(status: any) {
    status.selected = !status.selected;
  }

  onFilter() {
    let selectedStatuses: string[] = [];
    for (let status of this.statuses) {
      if (status.selected) {
        selectedStatuses.push(status.name);
      }
    }
    let filter = new BookingListFilter();
    filter.statuses = selectedStatuses;
    let fromDate = this.form.get('fromDate').value;
    if (fromDate != null && fromDate != '') {
      filter.fromDate = new Date(fromDate).toDateString();
    }
    let toDate = this.form.get('toDate').value;
    if (toDate != null && toDate != '') {
      filter.toDate = new Date(toDate).toDateString();
    }
    filter.employeeUserName = this.form.get('employeeUserName').value;
    this.filterEvent.emit(filter);
  }

  onReset() {
    this.filterEvent.emit(null);
    this.form.patchValue({
      employeeUserName: '',
      fromDate: '',
      toDate: ''
    });
    this.statuses = [
      { name: 'Created', selected: false },
      { name: 'Submitted', selected: true },
      { name: 'Accepted', selected: false },
      { name: 'Rejected', selected: false },
      { name: 'Completed', selected: false }
    ];
  }
}
