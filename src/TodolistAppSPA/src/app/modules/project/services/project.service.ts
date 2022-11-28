import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Board } from 'src/app/shared/models/board.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  baseUrl: string = "https://localhost:7041/api/board/"

  constructor(private httpClient: HttpClient) { }

  getBoard(id: number): Observable<Board> {
    return this.httpClient.get<Board>(this.baseUrl + id);
  }
}
