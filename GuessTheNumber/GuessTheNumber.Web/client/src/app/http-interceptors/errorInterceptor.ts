import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpErrorResponse
  } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { AuthService } from '../auth';
  
@Injectable()
  export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router, private authService: AuthService) {}
    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(request).pipe(
        catchError((error: HttpErrorResponse) => {
          // server-side error
          if (error.status >= 500){
            console.log(error);
            return throwError(error);
          }
          else {
            // client-side error
            if (error.status == 401){
                try{
                  // try to get new access token if refresh token is still valid
                  this.authService.refreshToken().subscribe();
                }
                catch{
                  this.router.navigate(['login']);
                }
                return;
            }
            return throwError(error);
          }
        })
      );
    }
  }