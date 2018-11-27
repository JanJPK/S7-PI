import { Injectable } from '@angular/core';
import { LogLevel } from './log-level.enum';
import { LoggerService } from './logger.service';

@Injectable({
  providedIn: 'root'
})
export class ConsoleLoggerService implements LoggerService {
  logLevel: LogLevel = LogLevel.ALL;

  constructor() {}

  log(message: string, logLevel: LogLevel) {
    if (logLevel >= this.logLevel) {
      console.log(`[${new Date()}][${logLevel}]: ${message}`);
    }
  }

  debug(message: string) {
    this.log(message, LogLevel.DEBUG);
  }

  info(message: string) {
    this.log(message, LogLevel.INFO);
  }

  warn(message: string) {
    this.log(message, LogLevel.WARN);
  }

  error(message: string) {
    this.log(message, LogLevel.ERROR);
  }
}
