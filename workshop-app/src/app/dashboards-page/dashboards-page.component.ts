import { Component } from '@angular/core';
import { BarplotComponent } from '../barplot/barplot.component';
import { DashboardsPageService } from './dashboards-page.service';
import { PizzaplotComponent } from "../pizzaplot/pizzaplot.component";


@Component({
    selector: 'app-dashboards-page',
    standalone: true,
    templateUrl: './dashboards-page.component.html',
    styleUrl: './dashboards-page.component.css',
    imports: [
        BarplotComponent,
        PizzaplotComponent
    ]
})
export class DashboardsPageComponent {

  quantidadeWorksshops: any[] = [];
  colaboradores: string[] = [];

  workshops: string[] = [];
  quantidadeColaboradores: any[] = [];
  constructor(private service: DashboardsPageService) {
    
  }

  ngOnInit(){
    this.obterDadosGraficoBarra();
    this.obterDadosGraficoPizza();

  }

  obterDadosGraficoBarra(){
    this.service.getQuantidadeWorkshopPorColaborador().subscribe(
      (resultado) => {
        this.colaboradores = Object.keys(resultado);
        this.quantidadeWorksshops = [{data: Object.values(resultado), label: 'Quantidade de Workshops'
      }];
    },
      (error) =>{
        console.log(error);
      }
    );
  }

  obterDadosGraficoPizza(){
    this.service.getQuantidadeColaboradorPorWorkshop().subscribe(
      (resultado) => {
        this.workshops = Object.keys(resultado);
        this.quantidadeColaboradores = [{data: Object.values(resultado), label: 'Quantidade de Colaboradores'
      }];
      },
      (error) =>{
        console.log(error);
      }
    )
  }
}
