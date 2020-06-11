import { Component } from '@angular/core';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularClient';

  constructor(private authService: AuthenticationService) {}

  getUserInfo() {
    console.log(this.authService.getUser());
  }

  login() {
    this.authService.signIn();
  }
}
