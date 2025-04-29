import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

export interface LoginRequest {
  email: string;
  senha: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = 'https://localhost:5001/api'; 

  constructor(private http: HttpClient) {}

  login(loginRequest: LoginRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, loginRequest).pipe(
      tap((response: any) => {
        if (response && response.token) {
          localStorage.setItem('token', response.token);
        }
      })
    );
  }
}
