import { Component, OnInit, EventEmitter } from '@angular/core';
import { GameService } from '../game.service';
import { GameMessage } from './models/gameMessage';
import { Game } from './models/game';

@Component({
  selector: 'app-gameplay',
  templateUrl: './gameplay.component.html',
  styleUrls: ['./gameplay.component.css']
})
export class GameplayComponent implements OnInit {

  public messages: GameMessage[] = new Array();

  public currentGameState: Game = {
    state: null,
    message: null,
    isOwner: false
  };

  public isGameOwner = () : boolean => { return this.currentGameState.isOwner }

  public noActiveGame = () : boolean => { return this.currentGameState.state != "active" }

  constructor(private gameService: GameService) { 
   this.updateState(true);
  }

  ngOnInit(): void {
    this.subscribeToEvents();
  }

  updateState(showMessage: boolean = false): void {
    this.gameService.updateState().subscribe(
      game => this.currentGameState = game,
      error => this.currentGameState = {
        message: error.error.message,
        state: "none",
        isOwner: false
      }).add(
        () => {
        if (showMessage){
          this.addMessage(this.currentGameState.message, false);
        }
      }
    );
  }

  sendGuess(number: number): void {
    this.addMessage(number.toString(), true);
    this.gameService.sendGuess(number).subscribe(
      guess => this.addMessage(guess.result, false),
      error => this.addMessage(error.error.message, false)
    );
  }

  startGame(number: number): void {
    this.addMessage(number.toString(), true);
    this.gameService.startGame(number).subscribe(
      newGame => this.addMessage(newGame.message, false),
      error => this.addMessage(error.error.message, false)
      ).add(() => this.updateState());
  }

  addMessage(message: string, fromMe: boolean): void{
    this.messages.push({messageText: message, fromMe: fromMe});
  }

  subscribeToEvents(): void {
    Object.keys(this.gameService.gameEvents).forEach((key: string) => {
        let event = this.gameService.gameEvents[key];
        event.subscribe(
          () => this.updateState()
        );
    });

    this.gameService.gameEvents.gameStarted.subscribe(
      (message: string) => this.addMessage(message, false));
    
    this.gameService.gameEvents.gameWon.subscribe(
      (winner: string) => this.addMessage(`${winner} has won the game.`, false));
    
    this.gameService.gameEvents.gameOver.subscribe(
      () => this.addMessage("Current game was aborted.", false));
  }

}
