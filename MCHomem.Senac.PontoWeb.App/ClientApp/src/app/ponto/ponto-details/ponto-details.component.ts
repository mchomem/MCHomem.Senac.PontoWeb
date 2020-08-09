import { Component, OnInit } from '@angular/core';
import { ColaboradorService } from '../../services/colaborador.service';
import { NgForm } from '@angular/forms';
import { Ponto } from '../../models/ponto-model';
import { PontoService } from '../../services/ponto.service';
import { Colaborador } from '../../models/colaborador-model';

@Component({
  selector: 'app-ponto-details',
  templateUrl: './ponto-details.component.html',
  styles: []
})
export class PontoDetailsComponent implements OnInit {

  ponto = {} as Ponto;
  colaborador = {} as Colaborador;
  operacoes = [
    { abreviacao: 'E', descricao: 'Entrada' }
    , { abreviacao: 'S', descricao: 'Saída' }
  ];

  constructor(private serviceColaborador: ColaboradorService, private servicePonto: PontoService) { }

  ngOnInit(): void {
    this.serviceColaborador.getColaboradores();
  }

  savePonto(form: NgForm) {

    this.ponto.DataHoraRegistroPonto = new Date();

    this
      .servicePonto
      .save(this.ponto)
      .subscribe(() => { alert('Ponto marcado!') });
  }

}
