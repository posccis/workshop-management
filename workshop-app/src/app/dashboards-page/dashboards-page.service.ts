import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardsPageService {
  private baseUrl = 'https://localhost:59088/api/';

  constructor(private http: HttpClient) {}

  getQuantidadeWorkshopPorColaborador(): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'atas/colaboradores/workshops/');

  }
  getQuantidadeColaboradorPorWorkshop(): Observable<any>{
    return this.http.get<any>(this.baseUrl + 'atas/workshops/colaboradores/');

  }
}
