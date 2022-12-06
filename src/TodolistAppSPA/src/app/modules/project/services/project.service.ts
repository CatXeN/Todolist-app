import { ReOrderTasks } from './../../../shared/models/re-order-task.model';
import { AddTask } from './../../../shared/models/add-task.model';
import { TransferTask } from './../../../shared/models/transfer-task.model';
import { List } from './../../../shared/models/list.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Board } from 'src/app/shared/models/board.model';
import { Task } from 'src/app/shared/models/task.model';
import { UsersAssignedToBoard } from 'src/app/shared/models/users-assinged-to-board.model';
import { AssignUserToBoard } from 'src/app/shared/models/assign-user-to-board.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  baseUrl: string = 'https://localhost:7041/api/board/';
  listUrl: string = 'https://localhost:7041/api/list/';
  taskUrl: string = 'https://localhost:7041/api/task/';

  constructor(private httpClient: HttpClient) { }

  getBoard(id: number): Observable<Board> {
    return this.httpClient.get<Board>(this.baseUrl + id);
  }

  getList(id: number): Observable<List[]> {
    return this.httpClient.get<List[]>(this.listUrl + id);
  }

  insertTask (data: AddTask): Observable<Task> {
    return this.httpClient.post<Task>(this.taskUrl, data);
  }

  transferTask(transferData: TransferTask): Observable<boolean> {
    return this.httpClient.post<boolean>(this.taskUrl + 'transferTask', transferData);
  }

  reOrder(tasks: ReOrderTasks): Observable<boolean> {
    return this.httpClient.post<boolean>(this.taskUrl + 'reOrder', tasks);
  }

  getUsersAssignedToBoard(boardId: number): Observable<UsersAssignedToBoard[]> {
    return this.httpClient.get<UsersAssignedToBoard[]>(this.baseUrl + 'GetAssignedUser/' + boardId);
  }

  assignUserToBoard(data: AssignUserToBoard) {
    return this.httpClient.post(this.baseUrl + 'assignUserToBoard', data);
  }

  isOwner(boardId: number): Observable<boolean> {
    const token: string = localStorage.getItem('token') || '';

    if (token) {
      var header = {
        headers: new HttpHeaders()
          .set('Authorization',  'bearer ' + token)
      };
  
      return this.httpClient.get<boolean>(this.baseUrl + 'isOwner/' + boardId, header)
    }

    throw new Error('invalid token');
  }
}
