import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators'
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  userData;
  accessToken;

  constructor(private http: HttpClient,
    private authService: AuthService) {
      this.userData = this.authService.getUser().then(user => {
        this.userData = user;
      });
    }

    getAllEmployees() {
      return this.http.get<any>(environment.apiUrl + `api/employee`)
        .pipe(
          map(res => {
            return res;
          })
        );
    }
    
}
