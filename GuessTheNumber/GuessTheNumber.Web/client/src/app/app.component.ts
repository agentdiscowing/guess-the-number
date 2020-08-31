import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from './auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  readonly title = 'Guess the Number';

  constructor(public authService: AuthService, private router: Router){
    if(this.authService.isLoggedIn()){
      this.router.navigate(['play']);
    }
    else{
      this.router.navigate(['login'])
    }

  }


}
