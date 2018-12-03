import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user/user.service';
import { Employee } from 'src/app/classes/employee/employee';

@Component({
  selector: 'app-dashboard-user-details',
  templateUrl: './dashboard-user-details.component.html',
  styleUrls: ['./dashboard-user-details.component.scss']
})
export class DashboardUserDetailsComponent implements OnInit {
  employee: Employee;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.employee = this.userService.getEmployee();
  }

  logout() {
    this.userService.logout();
  }
}
