import { DashboardService } from './../../services/dashboard.service';
import { Board } from './../../../../shared/models/board.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-board-list',
  templateUrl: './dashboard-board-list.component.html',
  styleUrls: ['./dashboard-board-list.component.scss']
})
export class DashboardBoardListComponent implements OnInit {

  boards: Board[] = [];

  constructor(private dashboardService: DashboardService) {}

  ngOnInit(): void {
    this.dashboardService.getBoards().subscribe(result => {
      this.boards = result;
    })
  }
}
