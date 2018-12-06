import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { VehicleModel } from '../classes/vehicle-model/vehicle-model';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService extends BaseService<
  VehicleModel,
  VehicleModel,
  number
> {
  constructor(
    http: HttpClient,
    userService: UserService,
    logger: LoggerService
  ) {
    super(http, 'vehicle-models', userService, logger);
  }

  getManufacturers(filter: any = null): Observable<string[]> {
    this.logger.info(
      `getManufacturers() @ ${this.apiUrl}vehicle-models; filter: ${filter}`
    );
    return this.http
      .get<string[]>(this.apiUrl, this.httpOptions)
      .pipe(catchError(this.handleError('get', [])));
  }
}
