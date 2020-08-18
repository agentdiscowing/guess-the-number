import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  
  loginForm: FormGroup;

  constructor(private authService: AuthService){}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      "email": new FormControl("", Validators.compose(
                                    [Validators.required, Validators.email])),
      "password": new FormControl("", Validators.compose(
                                    [Validators.required, Validators.minLength(5), Validators.maxLength(60)]))
    });
  }

  get email() { return this.loginForm.get('email'); }

  get password() { return this.loginForm.get('password'); }

  login(){
    if(this.loginForm.valid){
      this.authService.login(this.email.value, this.password.value).subscribe(
        _ => alert("Logged in"),
        error => console.log(error.error)
      );
    }
  }
}
