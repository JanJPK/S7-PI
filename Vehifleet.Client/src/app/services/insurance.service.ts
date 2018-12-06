import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Insurance } from '../classes/insurance/insurance';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class InsuranceService extends BaseService<
  Insurance,
  Insurance,
  number
> {
  constructor(
    http: HttpClient,
    userService: UserService,
    logger: LoggerService
  ) {
    super(http, 'insurances', userService, logger);
  }

  getByVehicleId(id: number): Observable<Insurance[]> {
    this.logger.info(`getByVehicleId (${id}) @ ${this.apiUrl}vehicle/${id}`);
    return this.http
      .get<Insurance[]>(`${this.getUrl()}vehicle/${id}`, {
        headers: this.headers
      })
      .pipe(catchError(this.handleError('getById', null)));
  }
}
