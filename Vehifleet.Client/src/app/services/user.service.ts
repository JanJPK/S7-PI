import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { baseDirectiveCreate } from '@angular/core/src/render3/instructions';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) {}

  login(username: string, password: string) {
    const credentials = {
      UserName: username,
      Password: password
    };
    this.httpClient
      .post(`${this.apiUrl}login`, JSON.stringify(credentials), {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }),
        responseType: 'text'
      })
      .subscribe(response => {
        console.log(response);
        let token = (<any>response).token;
        localStorage.setItem('jwt', token);
        //this.invalidLogin = false;
        //this.router.navigate(['/']);
      }),
      err => {
        //this.invalidLogin = true;
        console.log('login error');
      };
  }
}
