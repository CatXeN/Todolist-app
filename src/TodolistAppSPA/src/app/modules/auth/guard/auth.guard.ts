import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import jwt_decode, { JwtHeader } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(public router: Router) {}
  
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    const token = localStorage.getItem('token');
    if (token) {
        const jwt: any = jwt_decode(token);
        const expired = jwt.exp;

        if (Date.now() >= expired * 1000) {
            this.router.navigate(['']);
            return false;
        }

        return true;
    }

    this.router.navigate(['']);
    return false;
  }
}