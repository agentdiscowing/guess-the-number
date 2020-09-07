import { Component, OnInit } from '@angular/core';
import { CommentService } from '../comment.service';
import { Comment } from '../models/comment';

@Component({
  selector: 'app-comment-section',
  templateUrl: './comment-section.component.html',
  styleUrls: ['./comment-section.component.css']
})
export class CommentSectionComponent implements OnInit {

  public comments: Comment[];

  constructor(private commentService: CommentService) { }

  ngOnInit(): void {
    this.subscribeToEvents();
    this.getComments();
  }

  getComments(){
    this.commentService.getComments().subscribe(
      comments => this.comments = comments
    )
  }

  sendComment(text: string){
    this.commentService.sendComment(text).subscribe(
      message => {
        message.isOwned = true;
        this.comments.push(message)
      }
    );
    document.getElementById('commentText').value = "";
  }

  private subscribeToEvents(){
    this.commentService.commentEvents.commentAdded.subscribe(
      newComment => this.comments.push(newComment)
    );

    this.commentService.commentEvents.commentDeleted.subscribe(
      deletedId => this.comments = this.comments.filter(c => c.id !== deletedId)
    );

    this.commentService.commentEvents.commentEdited.subscribe(
      editedComment => {
        let comment = this.comments.find(c => c.id == editedComment.id);
        comment.text = editedComment.text;
      }
    );
  }

}
