import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpParams,
  HttpHeaders
} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs/operators';
import { LoggerService } from '../shared/logger/logger.service';
import { UserService } from '../shared/user/user.service';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService<TEntity, TEntityListItem, TKey> {
  protected apiUrl: string;
  protected headers = new HttpHeaders({
    'Content-Type': 'application/json',
    Authorization: 'Bearer ' + this.userService.getToken()
  });
  protected httpOptions = {
    headers: this.headers
  };

  constructor(
    protected http: HttpClient,
    protected apiType: string,
    protected userService: UserService,
    protected logger: LoggerService
  ) {
    this.apiUrl = `${environment.apiUrl}${apiType}/`;
  }

  get(filter: any = null): Observable<TEntityListItem[]> {
    console.log(this.headers);
    this.logger.info(`get() @ ${this.apiUrl}; filter: ${filter}`);
    if (filter) {
      return this.http
        .get<TEntityListItem[]>(this.apiUrl, {
          params: filter,
          headers: this.headers
        })
        .pipe(catchError(this.handleError('get', [])));
    } else {
      return this.http
        .get<TEntityListItem[]>(this.apiUrl, this.httpOptions)
        .pipe(catchError(this.handleError('get', [])));
    }
  }

  getById(id: TKey): Observable<TEntity> {
    this.logger.info(`getById (${id}) @ ${this.apiUrl}`);
    return this.http
      .get<TEntity>(`${this.getUrl()}${id}`, this.httpOptions)
      .pipe(catchError(this.handleError('getById', null)));
  }

  create(entity: TEntity): Observable<TKey> {
    this.logger.info(`create @ ${this.apiUrl}`);
    console.log(entity);
    return this.http
      .post<TEntity>(this.getUrl(), entity, this.httpOptions)
      .pipe(catchError(this.handleError('create', null)));
  }

  update(entity: TEntity, id: TKey): Observable<Response> {
    this.logger.info(`update @ ${this.apiUrl}`);
    console.log(entity);
    return this.http
      .put<TEntity>(`${this.getUrl()}${id}`, entity, {
        observe: 'response',
        headers: this.headers
      })
      .pipe(catchError(this.handleError('update', null)));
  }

  delete(id: TKey): Observable<{}> {
    this.logger.info(`delete (${id}) @ ${this.apiUrl}`);
    return this.http
      .delete(`${this.getUrl()}${id}`, {
        observe: 'response',
        headers: this.headers
      })
      .pipe(catchError(this.handleError('delete', null)));
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
      return of(result as T);
    };
  }
}
