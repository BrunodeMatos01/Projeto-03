import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutoService } from '../../services/produto.service';

@Component({
  selector: 'app-produto',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './produto.component.html',
  styleUrl: './produto.component.css'
})

export class ProdutoComponent {
  @Input() id:number = 0;
  @Input() nome:string = '';
  @Input() valor:string = '';
  @Input() estoque:number = 0;

  dados: any;
  produtosApi: any;
  servicosApi: any;

  constructor(private router: Router, private produtoService: ProdutoService, private routerActive : ActivatedRoute) { }

  ngOnInit(): void {
      this.getProdutos();   
  }

  getProdutos() {
    this.produtoService.getProdutos().subscribe({
      next: (response) => {
      this.produtosApi = response;
      },
      error: (erro) => {
        debugger;
        alert(`Ocorreu um erro ao realizar a requisição: ${erro}`);     
      },
    });
  }

  addProduto() {
    this.router.navigate(['/produto-cadastro']);
  }

  editarProduto(id: number) 
  {
    this.router.navigate(['/produto-cadastro', id]);
  }

  removerProduto(id: number) {
    this.produtoService.delete(id).subscribe({
      next: (response) => {
        this.getProdutos();
        alert('Produto excluido com sucesso!');
      },
      error: (erro) => {

        if (erro.status === 404) {
          alert('Produto não encontrado!');
          return;
        }

        alert('Ocorreu um erro ao exclir o Produto na api => /api/Produtos');
        console.log(`Ocorreu um erro ao realizar a requisição: ${erro}`);        
      },
    });
  }

  voltar(){
    this.router.navigate(['/home']);
  }

  formatCurrency(value: number): string {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(value);
  }
}


