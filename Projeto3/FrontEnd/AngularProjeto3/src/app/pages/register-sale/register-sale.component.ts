import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { saleRequest, SaleService } from '../../services/sale.service';

@Component({
  selector: 'app-register-sale',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './register-sale.component.html',
  styleUrl: './register-sale.component.css'
})
export class RegisterSaleComponent {
  constructor(private router : Router, private saleService : SaleService) {}

  saleRequest : saleRequest = {
    id: 0,
    products: [],
    date: new Date(),
  };


  save(form : any) {
    this.saleService.insert(form);
    this.router.navigate(['/sales']);
  }
  back() {
    this.router.navigate(['/sales']);
  }
}
