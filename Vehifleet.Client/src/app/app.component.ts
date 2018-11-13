import { Component, NgModule } from '@angular/core';
import { UserService } from './services/user.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Vehifleet';
  loggedIn: boolean;
  loginForm: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
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
}
