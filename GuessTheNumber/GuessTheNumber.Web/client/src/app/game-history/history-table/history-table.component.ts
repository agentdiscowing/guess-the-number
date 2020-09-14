import { Component, OnInit } from '@angular/core';
import { HistoryService } from '../history.service';
import { GameInfo } from '../model/gameInfo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GameGuessesComponent } from '../game-guesses/game-guesses.component';
@Component({
  selector: 'app-history-table',
  templateUrl: './history-table.component.html',
  styleUrls: ['./history-table.component.css']
})
export class HistoryTableComponent implements OnInit {

  public fields: string[] = ["Number", "Span"];

  public games: GameInfo[];

  public currentPage: number = 1;

  constructor(private historyService: HistoryService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.games = new Array();
    this.loadMore();
  }

  loadMore(){
    this.historyService.getHistory(this.currentPage).subscribe(
      games => {
        this.games = this.games.concat(games);
        ++this.currentPage;
      }
    );
  }

  showGame(gameId: number){
    this.historyService.getGameGuesses(gameId).subscribe(
      guesses => {
        const modalRef = this.modalService.open(GameGuessesComponent);
        modalRef.componentInstance.guesses = guesses;
      }
    )
  }

}
