import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ata } from '../models/Ata';
import { FiltroAtaDTO } from '../models/FiltroAtaDTO';


@Injectable({
  providedIn: 'root'
})
export class AtasPageService {

  private baseUrl = 'https://localhost:59088/api/';

  constructor(private http: HttpClient) {}

  getAtas(): Observable<Ata[]>{
    return this.http.get<Ata[]>(this.baseUrl + 'atas/');
  }

  getAtasFiltradas(filtro: FiltroAtaDTO): Observable<Ata[]>{
    const params = new URLSearchParams(filtro as any).toString();
    console.log(this.baseUrl + `atas/filtro?${params}`);
    return this.http.get<Ata[]>(this.baseUrl + `atas/filtro?${params}`);
  }
}
