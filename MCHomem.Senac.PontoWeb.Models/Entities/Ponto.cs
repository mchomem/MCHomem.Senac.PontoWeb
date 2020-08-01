using System;
using System.ComponentModel.DataAnnotations;

namespace MCHomem.Senac.PontoWeb.Models.Entities
{
    [Serializable]
    public class Ponto
    {
        #region Properties

        public Int32? ID { get; set; }

        [Required]
        public Colaborador Colaborador { get; set; }

        public DateTimeOffset? DataHoraRegistroPonto { get; set; }

        public Char? IndicadorEntradaSaida { get; set; }

        #endregion
    }
}
