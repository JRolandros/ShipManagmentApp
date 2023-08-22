import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tap } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = '/api/auth';
  constructor(private http: HttpClient) { }

  public IsLoggedOn() : boolean {
    const token = localStorage.getItem('access_token');

    if (token)
      return true;

    return false;
  }

  public Login(username:string,password:string) :Observable<any>{
    console.log('service login start');

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { username, password };
    return this.http.post(`${this.apiUrl}`, body, { headers }).pipe(
      tap((resp:any)=>
      {
        if(resp && resp.token){
          localStorage.setItem('access_token', resp.token); // Save the token
        }
      })
    );
  }

  public Logout() :void{
    // Clear token from localStorage
    localStorage.removeItem('access_token');
  }
}
