import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { baseDirectiveCreate } from '@angular/core/src/render3/instructions';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { environment } from '../../environments/environment';
import { EmployeeLogin } from '../classes/employee/employeeLogin';
import { JwtHelperService } from '@auth0/angular-jwt';
import { decode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = environment.apiUrl;
  employeeLogin: EmployeeLogin;
  jwtHelper: JwtHelperService;

  constructor(private httpClient: HttpClient) {
    this.jwtHelper = new JwtHelperService();
  }

  login(username: string, password: string) {
    const credentials = {
      UserName: username,
      Password: password
    };
    console.log(credentials);
    this.httpClient
      .post(`${this.apiUrl}login`, JSON.stringify(credentials), {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      })
      .subscribe(response => {
        console.log(response);
        console.log(this.jwtHelper.decodeToken(this.getToken()));
        this.employeeLogin = <EmployeeLogin>response;
        let token = this.employeeLogin.jwt;
        localStorage.setItem('jwt', token);
        localStorage.setItem('user', JSON.stringify(this.employeeLogin));
        //this.invalidLogin = false;
        //this.router.navigate(['/']);
      }),
      err => {
        //this.invalidLogin = true;
        console.log('login error');
      };
  }

  checkLocalStorage() {
    console.log('Checking local storage.');
    if (!this.jwtHelper.isTokenExpired(this.getToken())) {
      this.employeeLogin = JSON.parse(localStorage.getItem('user'));
      console.log(this.employeeLogin);
    } else {
      console.log('Token expired.');
      localStorage.removeItem('user');
    }
  }

  getToken(): string {
    return localStorage.getItem('jwt');
  }

  getEmployee(): EmployeeLogin {
    return this.employeeLogin;
  }

  logout() {
    console.log('Logging out.');
    this.employeeLogin = null;
    localStorage.removeItem('jwt');
  }

  isLoggedIn(): boolean {
    if (!this.employeeLogin) {
      return false;
    }
    if (!this.jwtHelper.isTokenExpired(this.getToken())) {
      console.log('User is logged in, token is not expired.');
      return true;
    } else {
      this.logout();
      return false;
    }
  }

  hasRole(roles: string[]): boolean {
    let tokenRoles = this.jwtHelper.decodeToken(this.getToken()).role;
    console.log(`Roles found: ${tokenRoles}`);
    for (let role of tokenRoles) {
      if (role.indexOf(role) > -1) {
        return true;
      }
    }
    return false;
  }
}
