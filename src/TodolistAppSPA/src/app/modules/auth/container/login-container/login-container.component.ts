import { UserLogin } from './../../../../shared/models/user-login.model';
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { SnackbarService } from 'src/app/shared/services/snackbar.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login-container',
  templateUrl: './login-container.component.html',
  styleUrls: ['./login-container.component.scss']
})
export class LoginContainerComponent {

  loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  });
  jwtHelper = new JwtHelperService();

  constructor(private fb: FormBuilder, private authService: AuthService, private router:Router, private snackBar: SnackbarService) {}

  login(): void {
    if (this.loginForm.valid) {
      const data: UserLogin = {
        username: this.loginForm.controls.username.value,
        password: this.loginForm.controls.password.value
      }

      this.authService.login(data).subscribe({
          next: (token) => { 
            localStorage.setItem('token', token);
            this.router.navigate(['panel']);
            const decodedToken = this.jwtHelper.decodeToken(token);
            localStorage.setItem('id', decodedToken.nameid);
            localStorage.setItem('role', decodedToken.role);
            localStorage.setItem('name', decodedToken.unique_name);
          },
          error: (message) => {
            this.snackBar.openSnackBar(message.error, 'Ok')
          }
      });
    }
  }
}
