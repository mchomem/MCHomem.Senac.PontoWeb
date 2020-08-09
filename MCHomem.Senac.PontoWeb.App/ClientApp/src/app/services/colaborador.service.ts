import { Injectable } from '@angular/core';
import { Colaborador } from '../models/colaborador-model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ColaboradorService {

  colaborador: Colaborador;
  readonly backendUrl = 'http://localhost:65431';
  list: Colaborador[];

  constructor(private http: HttpClient) { }

  getColaboradores() {
    this.http
      .get(this.backendUrl + '/api/colaborador/all')
      .toPromise()
      .then(res => this.list = res as Colaborador[]);
  }
}
