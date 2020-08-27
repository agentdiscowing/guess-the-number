import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageComponent } from './message/message.component';
import { GameplayComponent } from './gameplay/gameplay.component';



@NgModule({
  declarations: [MessageComponent, GameplayComponent],
  imports: [
    CommonModule
  ],
  exports: [
    MessageComponent,
    GameplayComponent
  ],
})
export class GameModule { }
