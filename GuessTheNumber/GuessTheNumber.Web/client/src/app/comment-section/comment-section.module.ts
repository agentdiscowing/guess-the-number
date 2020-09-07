import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentComponent } from './comment/comment.component';
import { CommentSectionComponent } from './comment-section/comment-section.component';



@NgModule({
  declarations: [CommentComponent, CommentSectionComponent],
  imports: [
    CommonModule
  ],
  exports: [
    CommentComponent,
    CommentSectionComponent
  ]
})
export class CommentSectionModule { }
