import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpErrorResponse
  } from "@angular/common/http";
  import { Observable, throwError } from "rxjs";
  import { catchError } from "rxjs/operators";
  
  export class ErrorInterceptor implements HttpInterceptor {
    intercept(
      request: HttpRequest<any>,
      next: HttpHandler
    ): Observable<HttpEvent<any>> {
      return next.handle(request).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error instanceof HttpErrorResponse) {
            // server-side error
            console.log(error);
            return throwError(error);
          } else {
            // client-side error
            return throwError(error);
          }
        })
      );
    }
  }