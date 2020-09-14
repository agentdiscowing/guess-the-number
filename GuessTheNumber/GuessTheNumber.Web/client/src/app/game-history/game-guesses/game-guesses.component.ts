import { Component, Input, OnInit } from '@angular/core';
import { Guess } from '../model/guess';

@Component({
  selector: 'app-game-guesses',
  templateUrl: './game-guesses.component.html',
  styleUrls: ['./game-guesses.component.css']
})
export class GameGuessesComponent implements OnInit {

  @Input() public guesses: Guess[];

  constructor() { }

  ngOnInit(): void {
  }

}
