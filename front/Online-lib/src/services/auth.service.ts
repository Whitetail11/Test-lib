import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt'
import { Observable } from 'rxjs';
import { Login } from 'src/models/Login';
import { Token } from 'src/models/Token';
import { tap } from 'rxjs/operators';
import { Register } from 'src/models/Register';

export const ACCESS_TOKEN_KEY = 'access_token'

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private jwtHelper: JwtHelperService
  ) { }

  api = 'https://localhost:5001/api';

  login(login: Login): Observable<Token> {
    return this.httpClient.post<Token>(`${this.api}/account/login`, login).pipe(
      tap(token => {
        localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
      })
    );
  }
  register(register: Register): Observable<Token> {
    return this.httpClient.post<Token>(`${this.api}/account/register`, register).pipe(
      tap(token => {
        localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
      })
    );
  }
  logout(): void {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate(['']);
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  decodeToken() {
    const token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return this.jwtHelper.decodeToken(token);
  }
}