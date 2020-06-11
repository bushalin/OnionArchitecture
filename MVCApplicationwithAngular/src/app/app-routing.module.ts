import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthCallbackComponent } from './auth-callback/auth-callback/auth-callback.component';
import { AuthService } from 'src/services/auth.service';
import { HomeComponent } from './home/home/home.component';


const routes: Routes = [
  {
    path: '',
    children: []
  },
  {
    path: 'auth-callback',
    component: AuthCallbackComponent
  },
  {
    path: 'home',
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  providers: [AuthService],
  exports: [RouterModule]
})
export class AppRoutingModule { }
