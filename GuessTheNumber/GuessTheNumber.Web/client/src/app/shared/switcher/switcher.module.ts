import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwitcherComponent } from './switcher.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [SwitcherComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    SwitcherComponent
  ]
})
export class SwitcherModule { }
