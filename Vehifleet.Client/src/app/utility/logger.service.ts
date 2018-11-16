import { Injectable } from '@angular/core';
import { LogLevel } from './log-level.enum';

@Injectable({
  providedIn: 'root'
})
export abstract class LoggerService {
  constructor() {}

  abstract log(message: string, logLevel: LogLevel);
  abstract debug(message: string);
  abstract info(message: string);
  abstract warn(message: string);
  abstract error(message: string);
}
