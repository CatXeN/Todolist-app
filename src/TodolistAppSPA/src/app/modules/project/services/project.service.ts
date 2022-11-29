import { List } from './../../../shared/models/list.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Board } from 'src/app/shared/models/board.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  baseUrl: string = "https://localhost:7041/api/board/"
  listUrl: string = "https://localhost:7041/api/list/"

  constructor(private httpClient: HttpClient) { }

  getBoard(id: number): Observable<Board> {
    return this.httpClient.get<Board>(this.baseUrl + id);
  }

  getList(id: number): Observable<List[]> {
    return this.httpClient.get<List[]>(this.listUrl + id);
  }
}
