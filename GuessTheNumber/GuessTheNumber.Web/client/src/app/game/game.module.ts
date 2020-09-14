import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageComponent } from './message/message.component';
import { GameplayComponent } from './gameplay/gameplay.component';
import { GameRoutingModule } from './game-routing.module';
import { CommentSectionModule } from '../comment-section';

@NgModule({
  declarations: [MessageComponent, GameplayComponent],
  imports: [
    CommonModule,
    GameRoutingModule,
    CommentSectionModule
  ],
  exports: [
    MessageComponent,
    GameplayComponent
  ],
})
export class GameModule { }
