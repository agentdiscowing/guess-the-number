import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from './gameplay/models/game';
import { GameStartedResponse } from './gameplay/models/gameStartedResponse';
import { GuessResult } from './gameplay/models/guessResult';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private gameUrl = 'api/Game';  // URL to web api

  public currentGameState: Game;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {}

  getState(): Observable<Game>{
    let url = this.gameUrl + '/state';
    return this.http.get<Game>(url, this.httpOptions).pipe(
      tap({ next: (x) => { 
         this.currentGameState = x
      }})
    );
  }

  sendGuess(number: number): Observable<GuessResult> {
    let url = this.gameUrl + `/guess/${number}`;
    return this.http.post<GuessResult>(url, this.httpOptions).pipe(
      tap({ next: (x) => { 
        this.getState()
     }})
    );;
  }

  startGame(number: number): Observable<GameStartedResponse> {
    let url = this.gameUrl + `/start/${number}`;
    return this.http.post<GameStartedResponse>(url, this.httpOptions).pipe(
      tap({ next: (x) => { 
        this.getState()
     }})
    );
  }
}
