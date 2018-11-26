import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/utility/user.service';
import { EmployeeLogin } from 'src/app/classes/employee/employeeLogin';

@Component({
  selector: 'app-dashboard-user-details',
  templateUrl: './dashboard-user-details.component.html',
  styleUrls: ['./dashboard-user-details.component.scss']
})
export class DashboardUserDetailsComponent implements OnInit {
  employee: EmployeeLogin;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.employee = this.userService.getEmployee();
  }

  logout() {
    this.userService.logout();
  }
}
