import { AddTask } from './../../../../shared/models/add-task.model';
import { Task } from './../../../../shared/models/task.model';
import { ProjectService } from './../../services/project.service';
import { AddTaskModalComponent } from './../../modal/add-task-modal/add-task-modal.component';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-action-presenter',
  templateUrl: './action-presenter.component.html',
  styleUrls: ['./action-presenter.component.scss']
})
export class ActionPresenterComponent {
  boardId: number = 0;

  @Input() set board(id: number) {
    if (id !== undefined && id !== 0) { 
      this.boardId = id;
    }
  }

  @Output() messageEvent = new EventEmitter<string>();


  constructor(public dialog: MatDialog, private projectService: ProjectService) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(AddTaskModalComponent, {
      width: '500px',
      data: {boardId: this.boardId},
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        const task: AddTask = {
          name: result.event.name,
          description: result.event.description,
          listId: result.event.listId
        }

        this.projectService.insertTask(task).subscribe(result => {
          this.sendMessage();
        });
      }
    });
  }

  sendMessage() {
    this.messageEvent.emit('created task');
  }
}
