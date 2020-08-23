import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { AuthResult } from './authResult';
import { NewUser } from './register/newUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private authUrl = 'api/Account';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {}

  login(email: string, password: string) : Observable<AuthResult>{
    let url = this.authUrl + "/login";
    return this.http.post<AuthResult>(url, {email, password}, this.httpOptions).pipe(
      tap({ next: (x) => { 
        this.setSession(x) 
      }})
    );
  }

  register(newUser: NewUser) : Observable<AuthResult>{
    let url = this.authUrl + "/register";
    return this.http.post<AuthResult>(url, newUser, this.httpOptions).pipe(
      tap({ next: (x) => { 
        this.setSession(x) 
      }})
    );
  }

  isLoggedIn(): boolean{
    return localStorage.getItem('id_token') !== null
  }

  logOut(): void{
    localStorage.removeItem('id_token');
  }

  private setSession(authResult: AuthResult) {
    localStorage.setItem('id_token', authResult.token);
  }
}
