import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { Comment } from './models/comment';
import { map, tap } from 'rxjs/operators';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private commentUrl = 'api/Comment';  // URL to web api
  
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  editComment(commentId: number, text: string): Observable<void>{
    let url = `${this.commentUrl}/edit/${commentId}`;
    return this.http.put<void>(url, {text}, this.httpOptions);
  }

  deleteComment(commentId: number): Observable<void> {
    let url = `${this.commentUrl}/delete/${commentId}`;
    return this.http.delete<void>(url, this.httpOptions);
  }

  getComments(): Observable<Comment[]>{
    let url = `${this.commentUrl}/all`;
    return this.http.get<Comment[]>(url, this.httpOptions).pipe(
      tap(comments => comments.forEach(c => c.postDate = moment(c.postDate).toDate()))
    );
  }

  sendComment(text: string): Observable<Comment>{
    let url = `${this.commentUrl}/send`;
    return this.http.post<Comment>(url, {text}, this.httpOptions);
  }

}
