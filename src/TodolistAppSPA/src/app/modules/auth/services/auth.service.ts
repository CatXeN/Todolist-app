import { UserLogin } from './../../../shared/models/user-login.model';
import { UserRegistration } from './../../../shared/models/user-registration.model';
import { Observable } from 'rxjs';
import { User } from './../../../shared/models/user.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl: string = "https://localhost:7041/api/auth"

  constructor(private httpClient : HttpClient) { }

  register(data: UserRegistration): Observable<string> {
    return this.httpClient.post<string>(this.baseUrl + '/register', data);
  }

  login(data: UserLogin): Observable<string> {
    return this.httpClient.post<string>(this.baseUrl + '/login', data);
  }
}
