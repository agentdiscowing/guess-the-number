import { Component, OnInit } from '@angular/core';

import { AuthService } from '../auth.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { NewUser } from './newUser';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private authService: AuthService) {}

  get email() { return this.registerForm.get('email'); }

  get password() { return this.registerForm.get('password'); }

  get confirmPassword() { return this.registerForm.get('confirmPassword'); }

  get username() { return this.registerForm.get('username'); }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      "email": new FormControl("", [Validators.required, Validators.email]),
      "password": new FormControl("", [Validators.required, Validators.minLength(5), Validators.maxLength(60)]),
      "confirmPassword": new FormControl("", Validators.required),
      "username": new FormControl("", [Validators.required, Validators.minLength(5), Validators.maxLength(60)]) },
      {validators: [Validators.required]});
  }

  register(){
    if(this.registerForm.valid){
      this.authService.register(this.registerForm.value as NewUser).subscribe(
        _ => alert("Registered"),
        error => console.log(error.error)
      );
    }
  }
}
