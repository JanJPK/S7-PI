import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Insurance } from '../classes/insurance/insurance';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InsuranceService extends BaseService<
  Insurance,
  Insurance,
  number
> {
  constructor(http: HttpClient, logger: LoggerService) {
    super(http, 'insurances', logger);
  }

  getByVehicleId(id: number): Observable<Insurance[]> {
    this.logger.info(`getByVehicleId (${id}) @ ${this.apiUrl}`);
    return this.http
      .get<Insurance[]>(`${this.getUrl()}vehicle/${id}`)
      .pipe(catchError(this.handleError('getById', null)));
  }
}
