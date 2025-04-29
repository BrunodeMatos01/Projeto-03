import { Injectable } from '@angular/core';
import { enviroment } from '../../environments/environments';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProdutoComponent } from '../components/produto/produto.component';

export interface ProdutoRequest {
  id: string;
  nome: string;
  valor: string;
  estoque: string;
}

export interface ProdutoResponse {
  id: number;
}

@Injectable({
  providedIn: 'root'
})

export class ProdutoService {

  private apiUrl = `${enviroment.apiUrl}/Produtos`
  constructor(private http: HttpClient) { }

  getProdutos(): Observable<ProdutoComponent[]>{
    return this.http.get<ProdutoComponent[]>(this.apiUrl);
  }

  getProdutoById(id:number): Observable<ProdutoRequest> {
    return this.http.get<ProdutoRequest>(this.apiUrl+'/'+id);
  }

  delete(id:number): Observable<string> {
    return this.http.delete<string>(this.apiUrl + '/' + id);
  }

  salvar(produto: ProdutoRequest): Observable<ProdutoResponse> {
    return this.http.post<ProdutoResponse>(this.apiUrl, produto);
  }
 
}
