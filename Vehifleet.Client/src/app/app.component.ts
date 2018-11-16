import { Component, NgModule, OnInit } from '@angular/core';
import { UserService } from './utility/user.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Vehifleet';
  loginForm: FormGroup;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.checkLocalStorage();
  }
  isLoggedIn(): boolean {
    return this.userService.isLoggedIn();
  }

  getUserDisplayName(): string {
    let user = this.userService.getEmployee();
    return `${user.firstName} ${user.lastName} (${user.department})`;
  }
}
