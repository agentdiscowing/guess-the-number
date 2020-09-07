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
    this.getComments();
  }

  getComments(){
    this.commentService.getComments().subscribe(
      comments => this.comments = comments
    )
  }

  sendComment(text: string){
    this.commentService.sendComment(text).subscribe(
      message => this.comments.push(message)
    );
  }

}
