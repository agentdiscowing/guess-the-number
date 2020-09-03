import { Injectable, EventEmitter } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Game } from './gameplay/models/game';
import { GameStartedResponse } from './gameplay/models/gameStartedResponse';
import { GuessResult } from './gameplay/models/guessResult';
import * as signalR from '@microsoft/signalr';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private gameUrl = 'api/Game';  // URL to web api

  private hubConnection: signalR.HubConnection;
  
  public gameEvents = {
    gameStarted: new EventEmitter<string>(),
    gameWon: new EventEmitter<string>(),
    gameOver: EventEmitter,
  }

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    this.buildConnection();
    this.startConnection();
  }

  updateState(): Observable<Game> {
    let url = `${this.gameUrl}/state`;
    return this.http.get<Game>(url, this.httpOptions);
  }

  sendGuess(number: number): Observable<GuessResult> {
    let url = this.gameUrl + `/guess/${number}`;
    return this.http.post<GuessResult>(url, this.httpOptions);
  }

  startGame(number: number): Observable<GameStartedResponse> {
    let url = this.gameUrl + `/start/${number}`;
    return this.http.post<GameStartedResponse>(url, this.httpOptions);
  }

  private buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("/gamehub") //use your api adress here and make sure you use right hub name.
      .build();
  };

  private startConnection = () => {
    this.hubConnection
      .start()
      .then(() => {
        console.log("Connection Started...");
        this.registerEvents();
      })
      .catch(err => {
        console.log("Error while starting connection: " + err);

        //if you get error try to start connection again after 3 seconds.
        setTimeout(function() {
          this.startConnection();
        }, 3000);
      });
  };

  private registerEvents = () => {
    this.hubConnection.on("SendGameStartedMessage", (data: string) => {
      this.gameEvents.gameStarted.emit(data);
    });
    this.hubConnection.on("SendGameWonMessage", (data: string) => {
      this.gameEvents.gameWon.emit(data);
    });
  }

}
