import { Component } from '@angular/core';
import { BarplotComponent } from '../barplot/barplot.component';


@Component({
  selector: 'app-dashboards-page',
  standalone: true,
  imports: [
    BarplotComponent
  ],
  templateUrl: './dashboards-page.component.html',
  styleUrl: './dashboards-page.component.css'
})
export class DashboardsPageComponent {

}
