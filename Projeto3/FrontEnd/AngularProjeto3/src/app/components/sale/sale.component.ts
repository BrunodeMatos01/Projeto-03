import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { product_sale } from '../../services/sale.service';

@Component({
  selector: 'app-sale',
  imports: [CommonModule],
  templateUrl: './sale.component.html',
  styleUrl: './sale.component.css'
})
export class SaleComponent {
  @Input()
  id! : number;
  @Input()
  date! : Date;
  @Input()
  products_sales! : product_sale[];
}