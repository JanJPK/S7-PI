import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Vehicle } from '../classes/vehicle/vehicle';
import { VehicleListItem } from '../classes/vehicle/vehicle-list-item';
import { BaseService } from './base.service';
import { VehicleListFilter } from '../classes/vehicle/vehicle-list-filter';
import { LoggerService } from '../shared/logger/logger.service';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class VehicleService extends BaseService<
  Vehicle,
  VehicleListItem,
  number
> {
  constructor(
    http: HttpClient,
    userService: UserService,
    logger: LoggerService
  ) {
    super(http, 'vehicles', userService, logger);
  }
}
