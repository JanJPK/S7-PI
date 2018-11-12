import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Vehicle } from '../classes/vehicle/vehicle';
import { VehicleListItem } from '../classes/vehicle/vehicle-list-item';
import { BaseService } from './base.service';
import { VehicleListFilter } from '../classes/vehicle/vehicle-list-filter';

@Injectable({
  providedIn: 'root'
})
export class VehicleService extends BaseService<
  Vehicle,
  VehicleListItem,
  number
> {
  constructor(http: HttpClient) {
    super(http, 'vehicles');
  }

  getBookable(): Observable<VehicleListItem[]> {
    return this.http
      .get<VehicleListItem[]>(this.getUrl('bookable'))
      .pipe(catchError(this.handleError('get', [])));
  }
}
