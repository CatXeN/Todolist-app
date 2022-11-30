import { TransferTask } from './../../../../shared/models/transfer-task.model';
import { Task } from './../../../../shared/models/task.model';
import { ProjectService } from './../../services/project.service';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-to-do-list-presenter',
  templateUrl: './to-do-list-presenter.component.html',
  styleUrls: ['./to-do-list-presenter.component.scss']
})
export class ToDoListPresenterComponent {
  todo: Task[] = [];
  inProgress: Task[] = [];
  done: Task[] = [];

  boardId: number = 0;

  @Input() set board(id: number) {
    if (id !== undefined && id !== 0) { 
      this.getList(id);
      this.boardId = id;
    }
  }

  @Input() set message(data: string) {
    if (data === 'created task') {
      this.getList(this.boardId);
    }
  }

  getList(id: number) {
    this.projectService.getList(id).subscribe(result => {
      this.todo = result[0].tasks;
      this.inProgress = result[1].tasks;
      this.done = result[2].tasks;
    });
  }

  constructor(private projectService: ProjectService) {}

  drop(event: CdkDragDrop<Task[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const transferTask: TransferTask =  {
        taskId: event.previousContainer.data[event.previousIndex].id,
        listOrder: Number(event.container.id.split('cdk-drop-list-')[1]),
        boardId: this.boardId
      };

      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );

      this.projectService.transferTask(transferTask).subscribe(result => {

      });
    }
  }
}
