import { HTTP_INTERCEPTORS } from '@angular/common/http';

import {JwtInterceptor} from './jwtInterceptor';

/** Http interceptor providers in outside-in order */
export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
];