import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/utility/user.service';

@Component({
  selector: 'app-dashboard-user-details',
  templateUrl: './dashboard-user-details.component.html',
  styleUrls: ['./dashboard-user-details.component.scss']
})
export class DashboardUserDetailsComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit() {}

  logout() {
    this.userService.logout();
  }
}
