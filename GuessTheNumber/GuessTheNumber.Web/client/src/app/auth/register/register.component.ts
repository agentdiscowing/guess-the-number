import { Component, OnInit } from '@angular/core';

import { AuthService } from '../auth.service';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { NewUser } from './newUser';
import { mustMatchValidator } from '../../validators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  errorBlock: boolean;

  errorMes: string;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      "email": new FormControl("", [Validators.required, Validators.email]),
      "password": new FormControl("", [Validators.required, Validators.minLength(5), Validators.maxLength(60)]),
      "confirmPassword": new FormControl("", Validators.required),
      "username": new FormControl("", [Validators.required, Validators.minLength(5), Validators.maxLength(60)]) },
      mustMatchValidator("password", "confirmPassword"));
  }

  getControl(control: string): AbstractControl {
    return this.registerForm.get(control);
  }

  needsValidation(control: string): boolean {
    let ctrl = this.getControl(control);
    return ctrl.invalid && (ctrl.dirty || ctrl.touched)
  }

  register(){
    this.errorBlock = false;
    if(this.registerForm.valid){
      this.authService.register(this.registerForm.value as NewUser).subscribe(
        _ => alert("Registered"),
        error => {
          this.errorBlock = true;
          this.errorMes = error.error.message
        }
      );
    }
  }
}
