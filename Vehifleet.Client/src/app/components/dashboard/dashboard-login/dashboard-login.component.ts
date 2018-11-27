import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-dashboard-login',
  templateUrl: './dashboard-login.component.html',
  styleUrls: ['./dashboard-login.component.scss']
})
export class DashboardLoginComponent implements OnInit {
  invalidLogin: boolean;
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: [''],
      password: ['']
    });
  }

  login() {
    this.userService.login(
      this.loginForm.controls.username.value,
      this.loginForm.controls.password.value
    );
  }

  isLoggedIn(): boolean {
    return this.userService.isLoggedIn();
  }
}
