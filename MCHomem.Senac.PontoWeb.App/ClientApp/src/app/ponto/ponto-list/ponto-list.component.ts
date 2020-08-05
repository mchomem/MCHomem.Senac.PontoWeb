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

  public ponto = {} as PontoModel;
  public pontos: PontoModel[]
  public colaboradorID: string

  constructor(private servicePonto: PontoService, private serviceColaborador: ColaboradorService) { }

  ngOnInit(): void {    
    this.serviceColaborador.getColaboradores();
  }

  onOptionsSelected(value: string) {
    this.colaboradorID = value;
  }

  getPontoColaborador() {

    this.servicePonto.getPonto(this.colaboradorID).subscribe((pontos: PontoModel[]) => {
      this.pontos = pontos;
    });
  }

}
