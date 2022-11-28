import { ProjectContainerComponent } from './container/project-container/project-container.component';
import { ProjectRoutingModule } from './project-routing.module';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToDoListPresenterComponent } from './presenter/to-do-list-presenter/to-do-list-presenter.component';

@NgModule({
  imports: [
    CommonModule,
    ProjectRoutingModule,
    SharedModule
  ],
  declarations: [
    ProjectContainerComponent,
    ToDoListPresenterComponent
  ]
})
export class ProjectModule { }
