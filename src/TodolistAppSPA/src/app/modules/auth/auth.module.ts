import { AuthRoutingModule } from './auth-routing.module';
import { LoginContainerComponent } from './container/login-container/login-container.component';
import { RegisterContainerComponent } from './container/register-container/register-container.component';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    SharedModule
  ],
  declarations: [
    RegisterContainerComponent,
    LoginContainerComponent
  ]
})
export class AuthModule { }
