import { Component, Input } from '@angular/core';
import { NgChartsModule } from 'ng2-charts';

@Component({
  selector: 'app-barplot',
  standalone: true,
  imports: [
    NgChartsModule
  ],
  templateUrl: './barplot.component.html',
  styleUrl: './barplot.component.css'
})
export class BarplotComponent {
  @Input() chartData: Array<any> = [];
  @Input() chartLabels: Array<any> = [];
  public lineChartOptions: any = {
    responsive: true,
  };
  public lineChartLegend = true;
  public lineChartType = 'line';
}
