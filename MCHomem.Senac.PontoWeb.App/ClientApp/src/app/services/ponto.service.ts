import { Injectable, ɵSWITCH_RENDERER2_FACTORY__POST_R3__ } from '@angular/core';
import { Ponto } from '../models/ponto-model';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PontoService {

  readonly backendUrl = 'http://localhost:65431';
  list: Ponto[];

  constructor(private http: HttpClient) { }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  save(ponto: Ponto): Observable<Ponto> {
    return this
      .http
      .post<Ponto>(
        this.backendUrl + '/api/ponto'
        , JSON.stringify(ponto)
        , this.httpOptions
      )
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  getPonto(colaboradorID: string): Observable<Ponto[]> {
    // TODO utilizar objeto colaborador.
    return this.http
      .get<Ponto[]>(
        this.backendUrl + '/api/ponto/ponto-colaborador/?colaboradorID=' + colaboradorID
      )
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
      errorMessage = `Código do erro: ${error.status}, ` + `mensagem: ${error.message}`;
    }

    console.log(errorMessage);

    return throwError(errorMessage);
  };

}
