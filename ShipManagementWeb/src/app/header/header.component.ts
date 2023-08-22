import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'ship-app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  /**
   *
   */
  constructor(private _authService: AuthService,private _router:Router) {

  }
  public logOut(){
    this._authService.Logout();
    this._router.navigate(['/login']);
  }
}
