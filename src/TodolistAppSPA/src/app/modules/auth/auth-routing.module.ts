import { RegisterContainerComponent } from './container/register-container/register-container.component';
import { LoginContainerComponent } from './container/login-container/login-container.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: LoginContainerComponent
  },
  {
    path: 'register',
    component: RegisterContainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule {}
