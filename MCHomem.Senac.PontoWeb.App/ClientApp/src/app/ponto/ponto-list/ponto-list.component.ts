import { Component, OnInit } from '@angular/core';
import { PontoModel } from '../../models/ponto-model';
import { PontoService } from '../../services/ponto.service';
import { ColaboradorService } from '../../services/colaborador.service';

@Component({
  selector: 'app-ponto-list',
  templateUrl: './ponto-list.component.html',
  styles: []
})
export class PontoListComponent implements OnInit {

  public pontos: PontoModel[]

  constructor(private servicePonto: PontoService, private serviceColaborador: ColaboradorService) { }

  ngOnInit(): void {
    this.servicePonto.getPontos();
    this.serviceColaborador.getColaboradores();
  }

}
