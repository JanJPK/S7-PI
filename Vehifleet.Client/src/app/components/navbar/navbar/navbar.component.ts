import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.checkLocalStorage();
  }

  getUserDisplayName(): string {
    let user = this.userService.getEmployee();
    return `${user.firstName} ${user.lastName} (${user.department})`;
  }
}
