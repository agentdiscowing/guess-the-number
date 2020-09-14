import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { httpInterceptorProviders } from './http-interceptors';
import { SwitcherModule } from './shared/';
import { AppRoutingModule } from './app-routing.module';
import { AuthRoutingModule, LoginModule, RegisterModule } from './auth';
import { GameModule } from './game';
import { CommentSectionModule } from './comment-section';
import { GameHistoryModule, GameHistoryRoutingModule } from './game-history';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    LoginModule,
    RegisterModule,
    SwitcherModule,
    AppRoutingModule,
    AuthRoutingModule,
    GameModule,
    CommentSectionModule,
    GameHistoryModule,
    GameHistoryRoutingModule,
    NgbModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
