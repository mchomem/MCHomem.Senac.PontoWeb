import { Colaborador } from "./colaborador-model";

export class Ponto {
  ID: number;
  Colaborador: Colaborador;
  DataHoraRegistroPonto: Date;
  IndicadorEntradaSaida: string;
}
