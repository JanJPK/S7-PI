import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs/operators';
import { LoggerService } from '../utility/logger/logger.service';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService<TEntity, TEntityListItem, TKey> {
  protected apiUrl: string;

  constructor(
    protected http: HttpClient,
    protected apiType: string,
    protected logger: LoggerService
  ) {
    this.apiUrl = `${environment.apiUrl}${apiType}/`;
  }

  get(filter: any = null): Observable<TEntityListItem[]> {
    this.logger.info(`get() @ ${this.apiUrl}; filter: ${filter}`);
    if (filter) {
      let params = new URLSearchParams();
      for (let key in filter) {
        params.set(key, filter[key]);
      }
      return this.http
        .get<TEntityListItem[]>(this.apiUrl)
        .pipe(catchError(this.handleError('get', [])));
    } else {
      return this.http
        .get<TEntityListItem[]>(this.apiUrl)
        .pipe(catchError(this.handleError('get', [])));
    }
  }

  getById(id: TKey): Observable<TEntity> {
    this.logger.info(`getById (${id}) @ ${this.apiUrl}`);
    return this.http
      .get<TEntity>(`${this.getUrl()}${id}`)
      .pipe(catchError(this.handleError('getById', null)));
  }

  getUrl(address: string = null): string {
    if (address) {
      return this.apiUrl + address;
    } else {
      return this.apiUrl;
    }
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.logger.error(error);

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
