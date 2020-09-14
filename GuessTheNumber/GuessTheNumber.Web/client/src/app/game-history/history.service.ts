import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameInfo } from './model/gameInfo';
import { Guess } from './model/guess';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {

  private historyUrl = 'api/History';

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getHistory(page: Number): Observable<GameInfo[]> {
    let url = `${this.historyUrl}/${page}?gamesPerPage=12`;
    return this.http.get<GameInfo[]>(url, this.httpOptions);
  }

  getGameGuesses(gameId: number): Observable<Guess[]>{
    let url = `${this.historyUrl}/guesses/?gameId=${gameId}`;
    return this.http.get<Guess[]>(url, this.httpOptions);
  }
}
