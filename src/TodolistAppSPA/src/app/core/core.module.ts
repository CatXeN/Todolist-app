import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';

@NgModule({
  declarations: [
  ],
  imports: [
    RouterModule,
    CommonModule,
    HttpClientModule,
    SharedModule
  ],
  exports: []
})
export class CoreModule { }
