import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { VehicleModel } from '../classes/vehicle-model/vehicle-model';
import { HttpClient } from '@angular/common/http';
import { LoggerService } from '../shared/logger/logger.service';

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService extends BaseService<
  VehicleModel,
  VehicleModel,
  number
> {
  constructor(http: HttpClient, logger: LoggerService) {
    super(http, 'vehicle-models', logger);
  }
}
