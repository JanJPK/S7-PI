import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Employee } from '../../classes/employee/employee';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoggerService } from '../logger/logger.service';
import { Observable, of } from 'rxjs';
import { ModalService } from '../modal/modal.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = environment.apiUrl;
  employeeLogin: Employee;
  jwtHelper: JwtHelperService;

  constructor(
    private http: HttpClient,
    private logger: LoggerService,
    private modalService: ModalService
  ) {
    this.jwtHelper = new JwtHelperService();
  }

  login(username: string, password: string) {
    const credentials = {
      UserName: username,
      Password: password
    };
    this.logger.info(`Login; username: ${username}`);
    this.http
      .post(`${this.apiUrl}login`, JSON.stringify(credentials), {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      })
      .pipe(catchError(this.handleError('delete', null)))
      .subscribe(response => {
        console.log('dupa');
        console.log(response);
        this.employeeLogin = <Employee>response;
        let token = this.employeeLogin.jwt;
        localStorage.setItem('jwt', token);
        localStorage.setItem('user', JSON.stringify(this.employeeLogin));
      });
  }

  getEmployeeById(id: number): Observable<Employee> {
    this.logger.info(`getById (${id}) @ ${this.apiUrl}`);
    return this.http.get<Employee>(`${this.apiUrl}employees/${id}`);
  }

  logout() {
    console.log('Logging out.');
    this.employeeLogin = null;
    localStorage.removeItem('jwt');
  }

  checkLocalStorage() {
    this.logger.info('Checking local storage');
    if (!this.jwtHelper.isTokenExpired(this.getToken())) {
      this.employeeLogin = JSON.parse(localStorage.getItem('user'));
      this.logger.info(`Recovered employee: ${this.employeeLogin}`);
    } else {
      this.logger.info('Recovered token is expired');
      localStorage.removeItem('user');
    }
  }

  getToken(): string {
    return localStorage.getItem('jwt');
  }

  getEmployee(): Employee {
    return this.employeeLogin;
  }

  isLoggedIn(): boolean {
    if (!this.employeeLogin) {
      return false;
    }
    if (!this.jwtHelper.isTokenExpired(this.getToken())) {
      return true;
    } else {
      this.logger.warn('Token is expired');
      this.logout();
      return false;
    }
  }

  hasRole(roles: string[]): boolean {
    if (!this.isLoggedIn()) {
      return false;
    }
    let tokenRoles = this.jwtHelper.decodeToken(this.getToken()).role;
    for (let role of tokenRoles) {
      if (roles.indexOf(role) > -1) {
        return true;
      }
    }
    return false;
  }

  isElevatedUser(): boolean {
    return this.hasRole(['Administrator', 'Manager']);
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.logger.error(error);
      this.modalService.showErrorModal(
        'Login failed: incorrect username or password.'
      );
      return of(result as T);
    };
  }
}
