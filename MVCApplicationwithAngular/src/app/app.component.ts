import { Component } from '@angular/core';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private _authService: AuthService) {

  }
  title = 'Onion.MVCApplicationwithAngular';
  login() {
    this._authService.login();
  }
}
