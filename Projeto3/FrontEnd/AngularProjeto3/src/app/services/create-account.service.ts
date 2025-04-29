import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CreateAccountRequest {
  nome: string;
  email: string;
  senha: string;
  confirmSenha: string;
}

@Injectable({
  providedIn: 'root'
})
export class CreateAccountService {

  private apiUrl = 'https://localhost:5001/api/auth';

  constructor(private http: HttpClient) {}

  createAccount(createAccountRequest: CreateAccountRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, createAccountRequest);
  }
}
