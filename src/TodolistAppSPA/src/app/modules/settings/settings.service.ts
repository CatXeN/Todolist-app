import { GetUserInfo } from './../../shared/models/get-user-info.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  baseUrl: string = 'https://localhost:7041/api/user/';

  constructor(private httpClient: HttpClient) { }

  userInfo(): Observable<GetUserInfo> {
    const token: string = localStorage.getItem('token') || '';

    if (token) {
      var header = {
        headers: new HttpHeaders()
          .set('Authorization',  'bearer ' + token)
      };
  
      return this.httpClient.get<GetUserInfo>(this.baseUrl, header);    
    }

    throw Error('user error');
  }
}
