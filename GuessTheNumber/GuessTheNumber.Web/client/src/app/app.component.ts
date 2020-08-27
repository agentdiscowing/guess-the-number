import { Component } from '@angular/core';

import { AuthService } from './auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  readonly title = 'Guess the Number';

  constructor(public authService: AuthService){}
}
