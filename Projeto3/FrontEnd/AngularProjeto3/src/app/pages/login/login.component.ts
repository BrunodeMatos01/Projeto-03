import { Component }    from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginService, LoginRequest } from '../../services/login.service';
 
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginRequest: LoginRequest = {
    email: '',
    senha: ''
  };
 
  constructor(private router: Router, private loginService: LoginService) {}
 
  CreateAccount() {
    this.router.navigate(['/create-account']);
  }
 
  login(form: any) {
    if (form.invalid) {
      alert('Preencha todos os campos');
      return;
    }
  
    this.loginService.login(this.loginRequest).subscribe({
      next: (response) => {
        console.log('Login realizado com sucesso!', response);
  
        localStorage.setItem('authToken', response.token);
  
        this.router.navigate(['/register-sale']);
      },
      error: (error) => {
        console.error('Erro ao fazer login:', error);
        alert('Email ou senha incorretos');
      }
    });
  }
  
}