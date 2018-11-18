import { Injectable } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
  providedIn: 'root'
})
export class DatepickerConverterService {
  constructor() {}

  dateToNgbDate(date: Date): NgbDateStruct {
    //console.log(`Input date: ${date}`);
    let ngbDate = {
      year: date.getUTCFullYear(),
      month: date.getUTCMonth() + 1,
      day: date.getUTCDate()
    };
    //this.logNgbDate(ngbDate);
    return ngbDate;
  }

  logNgbDate(date: NgbDateStruct) {
    console.log(`${date.day} ${date.month} ${date.year}`);
  }
}
