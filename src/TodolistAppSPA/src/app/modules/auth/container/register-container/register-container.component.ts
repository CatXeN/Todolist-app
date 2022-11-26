import { AuthService } from './../../services/auth.service';
import { UserRegistration } from './../../../../shared/models/user-registration.model';
import { User } from './../../../../shared/models/user.model';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-container',
  templateUrl: './register-container.component.html',
  styleUrls: ['./register-container.component.scss']
})
export class RegisterContainerComponent {

  registerForm = this.fb.group({
    username: ['', Validators.required],
    email: ['', Validators.email],
    password: ['', Validators.required],
    agreeTerm: [false, Validators.requiredTrue]
  });

  constructor(private fb: FormBuilder, private authService: AuthService, private router:Router) {}

  register(): void {
    if (this.registerForm.valid) {
      const user: UserRegistration = {
        username: this.registerForm.controls.username.value,
        email: this.registerForm.controls.email.value,
        password: this.registerForm.controls.password.value
      }

      this.authService.register(user).subscribe(result => {
        console.log(result);
        if (result === 'The account has been created successfully') {
          this.router.navigate(['']);
        }       
      });
    }
  }
}
