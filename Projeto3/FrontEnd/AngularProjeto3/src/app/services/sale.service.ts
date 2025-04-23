import { Injectable } from '@angular/core';
import { SaleComponent } from '../components/sale/sale.component';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environment/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class SaleService {

  private apiUrl = `${environment.apiUrl}/sales`;

  constructor(private http : HttpClient) { }

  get() : Observable<SaleComponent[]>{
    return this.http.get<SaleComponent[]>(this.apiUrl);
  }
  getById(id : number) : Observable<SaleComponent>{
    return this.http.get<SaleComponent>(`{this.apiUrl}/{id}`).pipe();
  }

  delete(id : number) : Observable<string> {
    return this.http.delete<string>(this.apiUrl).pipe();
  }

}
