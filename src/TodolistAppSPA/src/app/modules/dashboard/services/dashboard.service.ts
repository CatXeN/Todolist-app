import { Board } from './../../../shared/models/board.model';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BoardNode } from 'src/app/shared/models/board-node.model';
import { AddBoard } from 'src/app/shared/models/add-board.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl: string = "https://localhost:7041/api/board"

  constructor(private httpClient: HttpClient) { }

  getBoards(): Observable<Board[]> {
    const token = localStorage.getItem('token');

    if (token) {
      var header = {
        headers: new HttpHeaders()
          .set('Authorization',  'bearer ' + token)
      };
  
      return this.httpClient.get<Board[]>(this.baseUrl, header);
    }

    throw new Error('invalid token');
  }

  getBoardsNode(): Observable<BoardNode[]> {
    const token = localStorage.getItem('token');

    if (token) {
      var header = {
        headers: new HttpHeaders()
          .set('Authorization',  'bearer ' + token)
      };
  
      return this.httpClient.get<Board[]>(this.baseUrl, header);
    }

    throw new Error('invalid token');
  }

  addBoard(addBoard: AddBoard): Observable<number> {
    return this.httpClient.post<number>(this.baseUrl, addBoard);
  }
}
