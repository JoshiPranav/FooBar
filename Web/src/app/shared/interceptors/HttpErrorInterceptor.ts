import { catchError, tap } from 'rxjs/internal/operators';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  private errorMessage = "Unknown error occurred. Please try again later.";
  constructor(private router: Router) {
  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe(
        tap(data => console.log(data)),
        catchError((error: HttpErrorResponse) => {
          // Needs to be enhanced for further error handling
          if(!(error.error instanceof ErrorEvent)) {
            if(error.status === 400 || error.status == 404) {
              this.errorMessage = error.status + ' :: ' + error.error;
            }
            else {
            this.errorMessage = error.message;
            }
          }
          this.router.navigate(['/error', this.errorMessage]);
          return throwError(error);
        })
    );
  }
}