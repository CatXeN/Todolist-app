import { DashboardRoutingModule } from './Dashboard-routing.module';
import { DashboardContainerComponent } from './container/dashboard-container/dashboard-container.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule
  ],
  declarations: [
    DashboardContainerComponent
  ]
})
export class DashboardModule { }
