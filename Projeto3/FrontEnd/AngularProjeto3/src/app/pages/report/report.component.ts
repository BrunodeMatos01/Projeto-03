import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApexLegend, ApexNonAxisChartSeries, ApexResponsive, NgApexchartsModule } from 'ng-apexcharts';
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle,
  ChartComponent
} from "ng-apexcharts";

import { HttpClient } from '@angular/common/http';

export type ChartOptionsPie = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  labels: string[];
  responsive: ApexResponsive[];
  legend: ApexLegend;
};

// Para gráfico de barras:
export type ChartOptionsBar = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  title: ApexTitleSubtitle;
  xaxis: ApexXAxis;
};


@Component({
  selector: 'app-report',
  standalone: true,
  imports: [CommonModule, NgApexchartsModule],
  templateUrl: './report.component.html',
  styleUrl: './report.component.css'
})
export class ReportComponent implements OnInit {
  public charProdutosMaisVendidos: Partial<ChartOptionsBar> = {};
  public chartEstoqueAtual: Partial<ChartOptionsBar> = {};

    constructor(private http: HttpClient) {}

    ngOnInit(): void {
      this.http.get<any[]>('http://localhost:57828/api/report/best-selling')
        .subscribe(data => {
          const series = data.map(p => p.quantidadeVendida);
          const categories = data.map(p => p.nome);
    
          this.charProdutosMaisVendidos = {
            series: series.length > 0 ? [{ name: 'Quantidade Vendida', data: series }] : [],
            chart: { type: "bar", height: 350 },
            title: { text: "Produtos Mais Vendidos" },
            xaxis: { categories: categories.length > 0 ? categories : ['Nenhum Produto'] }
          };
        });
//http://localhost:57828/api/report/best-selling
//http://localhost:57828/api/report/stock
        this.http.get<any[]>('http://localhost:57828/api/report/stock')
      .subscribe(data => {
        this.chartEstoqueAtual = {
          series: [{ name: "Estoque", data: data.map(p => p.quantidadeEmEstoque) }],
          chart: { type: "bar", height: 350 },
          title: { text: "Estoque Atual dos Produtos" },
          xaxis: { categories: data.map(p => p.nome) }
        };
      });
    
}
}


