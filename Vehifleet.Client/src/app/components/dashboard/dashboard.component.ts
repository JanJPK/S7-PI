import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit() {}

  isLoggedIn(): boolean {
    return this.userService.isLoggedIn();
  }
}
