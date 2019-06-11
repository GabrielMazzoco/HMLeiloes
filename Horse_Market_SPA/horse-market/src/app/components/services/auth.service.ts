import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  jwtHelper: JwtHelperService = new JwtHelperService();
  decodedToken: any;
  baseUrl: string = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  public login(user: User) {
    return this.http.post(`${this.baseUrl}Auth/login`, user).pipe(
      map((response: any) => {
        if (response.token) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('user', JSON.stringify(response.username));
          this.decodedToken = this.jwtHelper.decodeToken(response.token);
        }
      })
    )
  }
}
