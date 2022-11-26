import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  jwtHelper = new JwtHelperService();
  constructor(public router: Router) {}
  
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    const token = localStorage.getItem('token');
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);

      if (Date.now() >= decodedToken.exp * 1000) {
        this.router.navigate(['']);
        return false;
      }      

      return true;
    }

    this.router.navigate(['']);
    return false;
  }
}