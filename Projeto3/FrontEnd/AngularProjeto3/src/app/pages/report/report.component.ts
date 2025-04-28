import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgApexchartsModule } from 'ng-apexcharts';
import { ApexAxisChartSeries, ApexChart, ApexXAxis, ApexTitleSubtitle} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-report',
  standalone: true,
  imports: [CommonModule, NgApexchartsModule],
  templateUrl: './report.component.html',
  styleUrl: './report.component.css'
})
export class ReportComponent {
    chartOptions: ChartOptions;

  
    constructor() {
      this.chartOptions = {
        series: [
          {
            name: "Vendas",
            data: [10, 20, 30, 25, 40]
          }
        ],
        chart: {
          type: "bar",
          height: 350,
          width: 500,
          
        },
        xaxis: {
          categories: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio"]
        },
        title: {
          text: "Vendas por mês"
        }
      };
    }
}



