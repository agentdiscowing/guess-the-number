import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CommentService } from '../comment.service';
import { Comment } from '../models/comment';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {

  @Input() public comment: Comment;

  public editMode: boolean = false;

  constructor(private commentService: CommentService) { }

  ngOnInit(): void {
  }

  delete(){
    if(!this.comment.isOwned){
      return;
    }
    this.commentService.deleteComment(this.comment.id).subscribe();
  }

  edit(){
    if(!this.comment.isOwned){
       return;
    }
    this.editMode = true;
  }

  saveChanges(editedComment: string){
    this.editMode = false;
    this.commentService.editComment(this.comment.id, editedComment).subscribe();
  }

}
