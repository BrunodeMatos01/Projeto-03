import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutoRequest, ProdutoService } from '../../services/produto.service';

@Component({
  selector: 'app-produto-cadastro',
  imports: [FormsModule, CommonModule],
  templateUrl: './produto-cadastro.component.html',
  styleUrl: './produto-cadastro.component.css'
})
export class ProdutoCadastroComponent {
  produtoRequest: ProdutoRequest = {
    id: 'Auto',
    nome: '',
    valor: '',
    estoque: ''
  }

  id: number = 0;

  constructor(private router: Router, private produtoService: ProdutoService, private routerActive : ActivatedRoute) { }

  ngOnInit(): void 
  {
    this.id = Number(this.routerActive.snapshot.paramMap.get('id'));
 
    if(this.id > 0){
      this.getProdutoById();
    }    
  }

  getProdutoById()
  {
    this.produtoService.getProdutoById(this.id).subscribe({
      next: (response) => {
        this.produtoRequest = response;
      },
      error: (erro) => {
        alert('Ocorreu um erro ao buscar os produtos na api => /api/Produto');
        console.log(`Ocorreu um erro ao realizar a requisição: ${erro}`);
      },
    });
  }

  salvar(form: any)
  {

    if(form.invalid){
      alert('Preencha todos os campos!');
      return;
    }

    if(this.produtoRequest.id === 'Auto')
    {
      this.produtoRequest.id = '0';
    }

    this.produtoService.salvar(this.produtoRequest).subscribe({
      next: (response) => {
      
        alert('Produto salvo com sucesso! Código: '+ response.id);
        setTimeout(() => this.router.navigate(['/produtos']), 1500);
       
      },
      error: (error) => {
        alert('Erro ao salvar o produto! '+ error);
      }
    });
  }

  voltar()
  {
    this.router.navigate(['/produtos']);
  }
}