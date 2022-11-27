import { SharedModule } from './../../shared/shared.module';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardContainerComponent } from './container/dashboard-container/dashboard-container.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardBoardListComponent } from './presenter/dashboard-board-list/dashboard-board-list.component';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule
  ],
  declarations: [
    DashboardContainerComponent,
    DashboardBoardListComponent
  ]
})
export class DashboardModule { }
