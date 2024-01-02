import { Component, Input } from '@angular/core';
import { NgChartsModule } from 'ng2-charts';

@Component({
  selector: 'app-pizzaplot',
  standalone: true,
  imports: [
    NgChartsModule
  ],  templateUrl: './pizzaplot.component.html',
  styleUrl: './pizzaplot.component.css'
})
export class PizzaplotComponent {
  @Input() chartData: Array<any> = [];
  @Input() chartLabels: Array<any> = [];
  public pieChartOptions: any = {
    responsive: true,
  };
  public pieChartType = 'pie'; 
}
