import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from './gameplay/game';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private gameUrl = 'api/Game';  // URL to web api

  private currentGame: Game;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {}

  getState(): Observable<Game>{
    let url = this.gameUrl + '/state';
    return this.http.get<Game>(url, this.httpOptions).pipe(
      tap({ next: (x) => { 
         this.currentGame.state = x.state
      }})
    );
  }
}
