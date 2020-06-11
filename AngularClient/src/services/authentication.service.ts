import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _userManager: UserManager;
  private _user: User;

  constructor() {
    const settings = {
      authority: environment.stsAuthority,
      client_id: environment.clientId,
      redirect_uri: `${environment.clientRoot}auth-callback`,
      silent_redirect_uri: `${environment.clientRoot}auth-callback`,

      post_logout_redirect_uri: `${environment.clientRoot}`,

      response_type: "code",
      response_mode: "query",
      loadUserInfo: true,
      scope: environment.clientScope
    }

    this._userManager = new UserManager(settings);
  }


  signIn(): Promise<any> {
    return this._userManager.signinRedirect();
  }

  completeSignIn(): Promise<any> {
    return this._userManager.signinRedirectCallback().then(user => {
      this._user = user;
    });
  }

  getUser(): Promise<any> {
    return this._userManager.getUser();
  }
}
