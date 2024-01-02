import { Component } from '@angular/core';
import {NgFor, NgIf} from "@angular/common";
import $ from 'jquery';
import { SidebarComponent } from "../sidebar/sidebar.component";
import { AtasPageService } from './atas-page.service';
import { Ata} from '../models/Ata';
import { FiltroAtaDTO } from '../models/FiltroAtaDTO';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
    selector: 'app-atas-page',
    standalone: true,
    templateUrl: './atas-page.component.html',
    styleUrl: './atas-page.component.css',
    imports: [SidebarComponent, NgFor, NgIf, FormsModule]
})
export class AtasPageComponent {


    idItemClicado: number | null = null;
    numeroDeAtas: number | null = null;
    atasList : Ata[] = [];
    constructor(private service: AtasPageService) {
        
    }

    ngOnInit(){
        this.service.getAtas().subscribe(resultado => {
            this.atasList = resultado;
            this.numeroDeAtas = this.atasList.length;

        });
    }

    filtraAtas(valor: NgForm){
        const filtro: FiltroAtaDTO = {
            NomeColaborador: valor.value.colaboradorNome,
            NomeWorkshop: valor.value.workshopNome,
            DataRealizacao: valor.value.dataSelecionada
        };
        this.service.getAtasFiltradas(filtro).subscribe((resultado) => {
            console.log(resultado);
            this.atasList = resultado;
            this.numeroDeAtas = this.atasList.length;
        },(error) => {
            console.log(error.message);
        });
    }

    toggleMostrarColaboradores(id: number) {
        this.idItemClicado = this.idItemClicado === id ? null : id;
      }
    
      isMostrarColaboradores(id: number) {
        return this.idItemClicado === id;
      }

    retornaDia(data: string){
        const dia = new Date(data).getDate();
        return dia;
    }
    retornaMes(data: string){
        const siglasDosMeses: string[] = [
            'Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'
          ];
        const mes = siglasDosMeses[new Date(data).getMonth()];

        return mes.toUpperCase();
    }
}
