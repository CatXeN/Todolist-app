import { AddTaskModalComponent } from './../../modal/add-task-modal/add-task-modal.component';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-action-presenter',
  templateUrl: './action-presenter.component.html',
  styleUrls: ['./action-presenter.component.scss']
})
export class ActionPresenterComponent {
  constructor(public dialog: MatDialog) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(AddTaskModalComponent, {
      width: '500px',
      // data: {name: this.name, animal: this.animal},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      // this.animal = result;
    });
  }
}
