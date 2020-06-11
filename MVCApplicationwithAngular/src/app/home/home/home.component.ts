import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  employeeData;
  userData;
  constructor(private authService: AuthService,
    private userService: UserService) {
    this.authService.getUser().then(user =>{
      this.userData = user;
      console.log(this.userData);
    })
  }

  ngOnInit() {
    this.getEmployeeData();
  }

  getEmployeeData() {
    this.userService.getAllEmployees().subscribe(data => {
      this.employeeData = data;
    })
  }

}
