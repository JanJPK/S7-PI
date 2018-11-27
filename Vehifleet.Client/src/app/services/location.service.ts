import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';
import { BaseService } from './base.service';
import { Location } from 'src/app/classes/location/location';

@Injectable({
  providedIn: 'root'
})
export class LocationService extends BaseService<Location, string, string> {
  constructor(http: HttpClient, logger: LoggerService) {
    super(http, 'locations', logger);
  }
}
