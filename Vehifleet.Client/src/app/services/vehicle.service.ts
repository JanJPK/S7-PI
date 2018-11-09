import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Vehicle } from '../classes/vehicle';
import { VehicleListItem } from '../classes/vehicle-list-item';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class VehicleService extends BaseService {

  constructor(
    private http: HttpClient) {
      super();
    }

  getVehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(`${this.apiUrl}/vehicles`)
                    .pipe(catchError(this.handleError('getVehicles', [])))
  }

  getBookableVehicles(): Observable<VehicleListItem[]> {
    return this.http.get<VehicleListItem[]>(`${this.apiUrl}/vehicles/bookable`)
                    .pipe(catchError(this.handleError('getBookableVehicles', [])))
  }


  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
