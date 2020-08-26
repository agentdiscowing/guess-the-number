import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { JwtInterceptor } from './jwtInterceptor';
import { ErrorInterceptor } from './errorInterceptor';
/** Http interceptor providers in outside-in order */
export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
]