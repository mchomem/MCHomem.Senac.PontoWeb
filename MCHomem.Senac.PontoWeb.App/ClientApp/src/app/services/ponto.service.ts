import { Injectable } from '@angular/core';
import { PontoModel } from '../models/ponto-model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PontoService {

  ponto: PontoModel;

  readonly backendUrl = 'http://localhost:65431';
  list: PontoModel[];

  constructor(private http: HttpClient) { }

  postPonto() {
    return this.http.post(this.backendUrl + '/api/ponto/ponto', this.ponto)
  }

  getPontos() {

    // TODO: pass by paran on this method the name of collaborator.

    let data = {
      ID: null
      , Colaborador: {
        ID: null
        , Nome: null
      }
      , DataHoraRegistroPonto: null
      , IndicadorEntradaSaida: null
    }

    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    let params = new HttpParams()
      .set('requestData', encodeURIComponent(JSON.stringify(this.ponto)));

    this.http
      .get(this.backendUrl + '/api/ponto/ponto', {
        params: params
        , headers: headers
      })
      .toPromise()
      .then(res => this.list = res as PontoModel[]);
  }

}
