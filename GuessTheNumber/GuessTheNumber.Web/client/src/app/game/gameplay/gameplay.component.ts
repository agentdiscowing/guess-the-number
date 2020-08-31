import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { GameMessage } from './models/gameMessage';

@Component({
  selector: 'app-gameplay',
  templateUrl: './gameplay.component.html',
  styleUrls: ['./gameplay.component.css']
})
export class GameplayComponent implements OnInit {

  public messages: GameMessage[] = new Array();

  public noActiveGame: boolean = false;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.getState();
  }

  getState(): void {
    this.gameService.getState().subscribe(
      game => {
        this.messages.push({messageText: game.message, fromMe: false});
        if (game.state !== "active") {
           this.noActiveGame = true;
        }
      },
      error => this.messages.push({messageText: error.error.message, fromMe: false})
    );
  }

  sendGuess(number: number): void {
    this.messages.push({messageText: number.toString(), fromMe: true});
    this.gameService.sendGuess(number).subscribe(
      guess => this.messages.push({messageText: guess.result, fromMe: false}),
      error => this.messages.push({messageText: error.error.message, fromMe: false})
    );
  }

  startGame(number: number): void {
    this.messages.push({messageText: number.toString(), fromMe: true});
    this.gameService.startGame(number).subscribe(
      newGame => {
        this.messages.push({messageText: newGame.message, fromMe: false})
        this.noActiveGame = false;
      },
      error => this.messages.push({messageText: error.error.message, fromMe: false})
    );
  }

}
