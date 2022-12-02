import { SnackbarService } from './../../../../shared/services/snackbar.service';
import { AssignUserToBoard } from './../../../../shared/models/assign-user-to-board.model';
import { UsersAssignedToBoard } from './../../../../shared/models/users-assinged-to-board.model';
import { ProjectService } from './../../services/project.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-assigned',
  templateUrl: './user-assigned.component.html',
  styleUrls: ['./user-assigned.component.scss']
})
export class UserAssignedComponent {
  boardId: number = 0;
  email: string = '';

  @Input() set board(id: number) {
    if (id !== undefined && id !== 0) { 
      this.boardId = id;

      this.projectService.getUsersAssignedToBoard(this.boardId).subscribe(x => {
        this.dataSource = x;
      })
    }
  }

  displayedColumns: string[] = ['No.', 'E-mail', 'Action'];
  dataSource: UsersAssignedToBoard[] = [];

  constructor(private projectService: ProjectService, private snackbarService: SnackbarService) {}
  
  assignUserToBoard() {
    const json: AssignUserToBoard = {
      boardId: this.boardId,
      email: this.email
    }

    this.projectService.assignUserToBoard(json).subscribe({
        next: () => {
          this.snackbarService.openSnackBar('Successfully added a user to the board', 'Ok');
          this.projectService.getUsersAssignedToBoard(this.boardId).subscribe(x => {
            this.dataSource = x;
          })
        },
        error: (error) => {
          this.snackbarService.openSnackBar(error.error, 'Ok');
        }
      }
    )
  }
}
