import { Injectable } from '@angular/core';
import { Maintenance } from '../classes/maintenance/maintenance';
import { LoggerService } from '../shared/logger/logger.service';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class MaintenanceService extends BaseService<
  Maintenance,
  Maintenance,
  number
> {
  constructor(
    http: HttpClient,
    userService: UserService,
    logger: LoggerService
  ) {
    super(http, 'maintenances', userService, logger);
  }

  getByVehicleId(id: number): Observable<Maintenance[]> {
    this.logger.info(`getByVehicleId (${id}) @ ${this.apiUrl}vehicle/${id}`);
    return this.http
      .get<Maintenance[]>(`${this.getUrl()}vehicle/${id}`, {
        headers: this.headers
      })
      .pipe(catchError(this.handleError('getById', null)));
  }
}
