import { Component, OnInit } from '@angular/core';
import { Ponto } from '../../models/ponto-model';
import { PontoService } from '../../services/ponto.service';
import { ColaboradorService } from '../../services/colaborador.service';

@Component({
  selector: 'app-ponto-list',
  templateUrl: './ponto-list.component.html',
  styles: []
})
export class PontoListComponent implements OnInit {

  public ponto = {} as Ponto;
  public pontos: Ponto[]
  public colaboradorID: string

  constructor(private servicePonto: PontoService, private serviceColaborador: ColaboradorService) { }

  ngOnInit(): void {    
    this.serviceColaborador.getColaboradores();
  }

  onOptionsSelected(value: string) {
    this.colaboradorID = value;
  }

  getPontoColaborador() {

    this
      .servicePonto
      .getPonto(this.colaboradorID)
      .subscribe((pontos: Ponto[]) => { this.pontos = pontos; });
  }

}
