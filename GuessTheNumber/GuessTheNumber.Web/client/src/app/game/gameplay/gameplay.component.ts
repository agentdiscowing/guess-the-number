import { Component, OnInit } from '@angular/core';
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
    message: null
  };

  public isGameOwner: boolean;

  public noActiveGame = () : boolean => this.currentGameState.state != "active";

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
        state: "none"
      },
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
      newGame => {
        this.addMessage(newGame.message, false);
        this.isGameOwner = true;
      },
      error => this.addMessage(error.error.message, false)
    );
  }

  addMessage(message: string, fromMe: boolean): void{
    this.messages.push({messageText: message, fromMe: fromMe});
  }

  subscribeToEvents(): void {
    this.gameService.gameEvents.gameStarted.subscribe(
      (username: string) => {
        this.addMessage(`${username} has started a new game`, false);
        this.updateState();
      }
    )
    this.gameService.gameEvents.gameWon.subscribe(
      (username: string) => {
        this.addMessage(`${username} has won the game`, false);
        this.updateState();
      }
    )
  }

}
