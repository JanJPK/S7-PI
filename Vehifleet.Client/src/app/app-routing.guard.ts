import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './services/user.service';
import { AppRoutingModule } from './app-routing.module';
import { JwtHelper } from 'node_modules/angular2-jwt';

@Injectable({
  providedIn: 'root'
})
export class AppRoutingGuard implements CanActivate {
  constructor(
    private appRouting: AppRoutingModule,
    private jwtHelper: JwtHelper
  ) {}

  canActivate() {
    var token = localStorage.getItem('jwt');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      console.log(this.jwtHelper.decodeToken(token));
      return true;
    } else {
      return false;
    }
  }
}
