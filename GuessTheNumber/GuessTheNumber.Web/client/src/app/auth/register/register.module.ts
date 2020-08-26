import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AuthRoutingModule } from '../auth-routing.module';
import { RegisterComponent } from './register.component';
import { ErrorModule } from '../../shared';

@NgModule({
  declarations: [RegisterComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AuthRoutingModule,
    ErrorModule
  ]
})
export class RegisterModule { }
