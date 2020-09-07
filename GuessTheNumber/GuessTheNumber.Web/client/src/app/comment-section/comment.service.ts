import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { Comment } from './models/comment';
import { EditedComment } from './models/editedComment';
import { map, tap } from 'rxjs/operators';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private commentUrl = 'api/Comment';

  private hubConnection: signalR.HubConnection;

  public commentEvents = {
    commentAdded: new EventEmitter<Comment>(),
    commentDeleted: new EventEmitter<number>(),
    commentEdited: new EventEmitter<EditedComment>()
  }
  
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    this.buildConnection();
    this.startConnection();
   }

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
    return this.http.post<Comment>(url, {text}, this.httpOptions).pipe(
      tap(newComment => this.hubConnection.send("NewCommentAdded", newComment))
    );
  }

  private buildConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("/commenthub") //use your api adress here and make sure you use right hub name.
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
    this.hubConnection.on("NewCommentAdded", (data: Comment) => this.commentEvents.commentAdded.emit(data));
    this.hubConnection.on("CommentModified", (data: EditedComment) => this.commentEvents.commentEdited.emit(data));
    this.hubConnection.on("CommentDeleted", (data: number) => this.commentEvents.commentDeleted.emit(data));
  }

}
