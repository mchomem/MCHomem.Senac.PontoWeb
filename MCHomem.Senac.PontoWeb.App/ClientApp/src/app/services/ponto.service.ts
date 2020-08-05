import { Injectable, ɵSWITCH_RENDERER2_FACTORY__POST_R3__ } from '@angular/core';
import { PontoModel } from '../models/ponto-model';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

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

  getPonto(colaboradorID : string) : Observable<PontoModel[]>{
    return this.http
      .get<PontoModel[]>(this.backendUrl + '/api/ponto/ponto-colaborador/?colaboradorID=' + colaboradorID)
      .pipe(
        retry(2)
        , catchError(this.handleError)
      );
  }

  // Error handling
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Error occurred on the client side
      errorMessage = error.error.message;
    } else {
      // Error occurred on the server side
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}
