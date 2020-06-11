import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserManager, User } from 'oidc-client';
import { promise } from 'protractor';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _userManager: UserManager;
  private _user: User = null;

  constructor() {
    const settings = {
      authority: environment.stsAuthority,
      client_id: environment.clientId,
      redirect_uri: `http://localhost:4200/auth-callback`,
      silent_redirect_uri: `${environment.clientRoot}auth-callback`,
      post_logout_redirect_uri: `${environment.clientRoot}`,
      response_type: 'code',
      response_mode: 'query',
      loadUserInfo: true,
      code_challenge: 'S256',
      scope: environment.clientScope
    };

    this._userManager = new UserManager(settings);
    this._userManager.getUser().then(user => {
      this._user = user;
    });

  }

  login(): Promise<any> {
    return this._userManager.signinRedirect();
  }

  completeLogin(): Promise<any> {
    return this._userManager.signinRedirectCallback().then(user => {
      this._user = user;
      localStorage.setItem('accessToken', this._user['access_token']);
    })
  }

  getUser(): Promise<any> {
    return this._userManager.getUser();
  }

}
