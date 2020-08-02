import { Component, OnInit } from '@angular/core';
import { ColaboradorService } from '../../services/colaborador.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-ponto-details',
  templateUrl: './ponto-details.component.html',
  styles: []
})
export class PontoDetailsComponent implements OnInit {

  constructor(private serviceColaborador: ColaboradorService) { }

  ngOnInit(): void {
    this.serviceColaborador.getColaboradores();
  }

  onSubmit(form: NgForm) {

  }

}
