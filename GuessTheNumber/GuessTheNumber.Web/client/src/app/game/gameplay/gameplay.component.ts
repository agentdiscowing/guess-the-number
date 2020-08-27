import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { GameMessage } from './gameMessage';

@Component({
  selector: 'app-gameplay',
  templateUrl: './gameplay.component.html',
  styleUrls: ['./gameplay.component.css']
})
export class GameplayComponent implements OnInit {

  public messages: GameMessage[] = new Array(); ;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.getState();
  }

  getState(): void{
    this.gameService.getState().subscribe(
      value => this.messages.push({messageText: value.stateMessage, fromMe: false}),
      error => this.messages.push({messageText: error.error.message, fromMe: false}),
    )
  }

}
