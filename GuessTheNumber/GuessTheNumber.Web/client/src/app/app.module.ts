import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { httpInterceptorProviders } from './http-interceptors';
import { SwitcherModule } from './shared/';
import { AppRoutingModule } from './app-routing.module';
import { AuthRoutingModule, LoginModule, RegisterModule } from './auth';

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
    AuthRoutingModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
