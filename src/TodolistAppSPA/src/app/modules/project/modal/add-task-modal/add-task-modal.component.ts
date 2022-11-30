import { List } from './../../../../shared/models/list.model';
import { ProjectService } from './../../services/project.service';
import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddTaskModal } from 'src/app/shared/models/modals/add-task-modal.model';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-task-modal',
  templateUrl: './add-task-modal.component.html',
  styleUrls: ['./add-task-modal.component.scss']
})
export class AddTaskModalComponent {
  lists: List[] = [];
  listsName: string[] = [];

  addTaskForm = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    listId: [, Validators.required]
  });

  constructor(
    public dialogRef: MatDialogRef<AddTaskModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddTaskModal,
    private projectService: ProjectService,
    private fb: FormBuilder
  ) {
    projectService.getList(data.boardId).subscribe(result => {
      this.lists = result;
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  addTask(): void {
    const data = {
      name: this.addTaskForm.controls.name.value,
      description: this.addTaskForm.controls.description.value,
      listId: this.addTaskForm.controls.listId.value,
    } 
    this.dialogRef.close({event:data});
  }
}
