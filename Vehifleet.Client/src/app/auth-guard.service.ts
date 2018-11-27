import { Injectable } from '@angular/core';
import { UserService } from './shared/user/user.service';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
  constructor(private userService: UserService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    let roles = route.data.expectedRoles;
    let canActivate: boolean;
    if (roles.length > 0) {
      canActivate = this.userService.hasRole(roles);
    } else {
      canActivate = this.userService.isLoggedIn();
    }

    if (canActivate) {
      return true;
    } else {
      this.router.navigate(['dashboard']);
      return false;
    }
  }
}
