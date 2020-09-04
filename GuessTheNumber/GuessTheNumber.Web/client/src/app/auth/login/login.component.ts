import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  errorBlock: boolean;

  errorMes: string;

  constructor(private authService: AuthService){}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      "email": new FormControl("", Validators.compose(
                                    [Validators.required, Validators.email])),
      "password": new FormControl("", Validators.compose(
                                    [Validators.required, Validators.minLength(5), Validators.maxLength(60)]))
    });
  }

  getControl(control: string): AbstractControl {
    return this.loginForm.get(control);
  }

  needsValidation(control: string): boolean {
    let ctrl = this.getControl(control);
    return ctrl.invalid && (ctrl.dirty || ctrl.touched)
  }

  login(){
    this.errorBlock = false;
    if(this.loginForm.valid){
      this.authService.login(this.getControl('email').value, this.getControl('password').value).subscribe(
        (error: any) => {
          this.errorBlock = true;
          this.errorMes = error.error.message
        }
      );
    }
  }
}
