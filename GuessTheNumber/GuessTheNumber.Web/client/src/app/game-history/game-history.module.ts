import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoryTableComponent } from './history-table/history-table.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { GameHistoryRoutingModule } from './game-history-routing.module';
import { GameGuessesComponent } from './game-guesses/game-guesses.component';

@NgModule({
  declarations: [HistoryTableComponent, GameGuessesComponent],
  imports: [
    CommonModule,
    InfiniteScrollModule,
    GameHistoryRoutingModule
  ]
})
export class GameHistoryModule { }
