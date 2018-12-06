import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';
import { BaseService } from './base.service';
import { Location } from 'src/app/classes/location/location';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService extends BaseService<Location, string, string> {
  constructor(
    http: HttpClient,
    userService: UserService,
    logger: LoggerService
  ) {
    super(http, 'locations', userService, logger);
  }
}
