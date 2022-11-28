import { Board } from './../../../shared/models/board.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BoardNode } from 'src/app/shared/models/board-node.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl: string = "https://localhost:7041/api/board"

  constructor(private httpClient: HttpClient) { }

  getBoards(): Observable<Board[]> {
    return this.httpClient.get<Board[]>(this.baseUrl);
  }

  getBoardsNode(): Observable<BoardNode[]> {
    return this.httpClient.get<Board[]>(this.baseUrl);
  }
}
