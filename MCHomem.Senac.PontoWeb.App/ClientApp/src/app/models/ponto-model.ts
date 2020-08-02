import { ColaboradorModel } from "./colaborador-model";

export class PontoModel {
  ID: number;
  Colaborador: ColaboradorModel;
  DataHoraRegistroPonto: string;
  IndicadorEntradaSaida: string;
}
