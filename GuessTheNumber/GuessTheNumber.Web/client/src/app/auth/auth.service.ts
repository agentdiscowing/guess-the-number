import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable } from 'rxjs';
import { tap, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';

import { AuthResult } from './authResult';
import { NewUser } from './register/newUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authUrl = 'api/Account';  // URL to web api

  private jwtHelper: JwtHelperService = new JwtHelperService();

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string) : Observable<AuthResult>{
    let url = this.authUrl + "/login";
    return this.http.post<AuthResult>(url, {email, password}, this.httpOptions).pipe(
      tap({ next: (x) => { 
        this.setSession(x);
        this.router.navigate(['play']);
      }})
    );
  }

  register(newUser: NewUser) : Observable<AuthResult>{
    let url = this.authUrl + "/register";
    return this.http.post<AuthResult>(url, newUser, this.httpOptions).pipe(
      tap({ next: (x) => { 
        this.setSession(x);
        this.router.navigate(['play']);
      }})
    );
  }

  isLoggedIn(): boolean {
    let accessToken = localStorage.getItem('id_token'),
        refreshToken = localStorage.getItem('refresh_token');

    if(!accessToken || !refreshToken){
      return false;
    }

    if(!this.jwtHelper.isTokenExpired(accessToken)){
      return true;
    }
  }

  logOut(): void{
    let url = this.authUrl + "/logout";
    this.stopRefreshTokenTimer();
    this.http.post(url, {}, this.httpOptions).subscribe();
    localStorage.removeItem('id_token');
    localStorage.removeItem('refresh_token');
  }

  refreshToken(): Observable<AuthResult>{
    let url = this.authUrl + '/refresh';
    let data: AuthResult = {
      accessToken: localStorage.getItem("id_token"),
      refreshToken: localStorage.getItem("refresh_token")
    }
    return this.http.post<AuthResult>(url, data, this.httpOptions).pipe(
      tap(
        newKeys => this.setSession(newKeys),
        error => console.log(error)
      )
    );
  }
  
  private refreshTokenTimeout;

  private setSession(authResult: AuthResult): void {
    let expireTime = this.jwtHelper.getTokenExpirationDate(authResult.accessToken).getTime();

    // i refresh token 2 minutes before it is expired
    let refreshTime = expireTime - Date.now() - 120 * 1000;
    this.startRefreshTokenTimer(refreshTime);

    console.log(`${expireTime}, ${refreshTime}`);

    localStorage.setItem('id_token', authResult.accessToken);
    localStorage.setItem('refresh_token', authResult.refreshToken);
  }

  private startRefreshTokenTimer(timeout: number): void {
        this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout); 
  }

  private stopRefreshTokenTimer(): void {
    clearTimeout(this.refreshTokenTimeout);
}
}
