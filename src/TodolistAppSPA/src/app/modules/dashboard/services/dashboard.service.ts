import { Board } from './../../../shared/models/board.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  baseUrl: string = "https://localhost:7041/api/board"

  constructor(private httpClient: HttpClient) { }

  getBoards(): Observable<Board[]> {
    return this.httpClient.get<Board[]>(this.baseUrl);
  }
}
