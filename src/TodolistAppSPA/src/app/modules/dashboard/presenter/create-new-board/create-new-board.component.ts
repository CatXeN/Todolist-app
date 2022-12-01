import { DashboardService } from './../../services/dashboard.service';
import { Component } from '@angular/core';
import { AddBoard } from 'src/app/shared/models/add-board.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-new-board',
  templateUrl: './create-new-board.component.html',
  styleUrls: ['./create-new-board.component.scss']
})
export class CreateNewBoardComponent {
  name: string = '';

  constructor (private dashboardService: DashboardService, public router: Router) {}

  createBoard() {
    const addBoard: AddBoard = {
      name: this.name,
      userId: Number(localStorage.getItem('id'))
    }

    this.dashboardService.addBoard(addBoard).subscribe(id => {
      this.router.navigate(['panel/project/' + id]);
    });
  }
}
