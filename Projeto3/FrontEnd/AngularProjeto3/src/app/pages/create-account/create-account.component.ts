import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms'; // Certifique-se de importar NgForm
import { CreateAccountService, CreateAccountRequest } from '../../services/create-account.service';
 
@Component({
  selector: 'app-create-account',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent {
  createAccountRequest: CreateAccountRequest = {
    nome: '',
    email: '',
    senha: '',
    confirmSenha: ''
  };
 
  constructor(private router: Router, private createAccountService: CreateAccountService) {}
 
  BackToLogin() {
    this.router.navigate(['/login']);
  }
 
  createAccount(form: NgForm) {
    if (form.invalid || this.createAccountRequest.senha !== this.createAccountRequest.confirmSenha) {
      alert('Verifique os campos e se as senhas conferem.');
      return;
    }
 
    this.createAccountService.createAccount(this.createAccountRequest).subscribe({
      next: (response) => {
        console.log('Conta criada com sucesso!', response);
        alert('Conta criada com sucesso! Agora faça login.');
        this.router.navigate(['/login']);
      },
      error: (error) => {
        console.error('Erro ao criar conta:', error);
        alert('Erro ao criar conta. Tente novamente.');
      }
    });
  }
}
 