import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Employee } from '../../classes/employee/employee';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoggerService } from '../logger/logger.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = environment.apiUrl;
  employeeLogin: Employee;
  jwtHelper: JwtHelperService;

  constructor(private http: HttpClient, private logger: LoggerService) {
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
      .subscribe(response => {
        this.logger.info(`Login response: ${response}`);
        this.logger.info(
          `login token: ${this.jwtHelper.decodeToken(this.getToken())}`
        );
        this.employeeLogin = <Employee>response;
        let token = this.employeeLogin.jwt;
        localStorage.setItem('jwt', token);
        localStorage.setItem('user', JSON.stringify(this.employeeLogin));
        //this.invalidLogin = false;
        //this.router.navigate(['/']);
      }),
      err => {
        this.logger.warn(`Failed login: ${err}`);
        //this.invalidLogin = true;
      };
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
    //this.logger.info('Verifying user login');
    if (!this.employeeLogin) {
      return false;
    }
    if (!this.jwtHelper.isTokenExpired(this.getToken())) {
      //this.logger.info('Token is not expired');
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

    //this.logger.info(`Verifying user roles; need ${roles}`);
    let tokenRoles = this.jwtHelper.decodeToken(this.getToken()).role;
    //this.logger.info(`Roles found: ${tokenRoles}`);

    for (let role of tokenRoles) {
      if (role.indexOf(role) > -1) {
        return true;
      }
    }
    return false;
  }

  isElevatedUser(): boolean {
    return this.hasRole(['Administrator', 'Manager']);
  }
}
