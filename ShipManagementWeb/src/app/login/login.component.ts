import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'ship-app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  username: string = '';
  password: string = '';
  returnUrl: string='';
  constructor(private _authService: AuthService, private _snackBar: MatSnackBar,private _route: ActivatedRoute, private _router:Router) {

    //If the user is already logged in, redirect to home.
    if(_authService.IsLoggedOn())
      this._router.navigate(['/']);
    else{
      //If not, save the return url to go back after authentication, if no return url, go back to home.
      this.returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
    }
  }

  login() {
    if(this.username && this.password){

      //appel du service de login
      this._authService.Login(this.username, this.password)
      .subscribe(
        {
          next :(nodata)=>{
            this._snackBar.open("Connection réussie !",'Ok',{duration:1000});
            this._router.navigate([this.returnUrl]);
          },
          error : (e)=>{
            this._snackBar.open("Connection échouée !",'Ok',{duration:1000});
          }
        }
      );

    }

  }

}
