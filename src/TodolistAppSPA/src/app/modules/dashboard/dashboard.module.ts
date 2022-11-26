import { SharedModule } from './../../shared/shared.module';
import { DashboardRoutingModule } from './Dashboard-routing.module';
import { DashboardContainerComponent } from './container/dashboard-container/dashboard-container.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule
  ],
  declarations: [
    DashboardContainerComponent
  ]
})
export class DashboardModule { }
