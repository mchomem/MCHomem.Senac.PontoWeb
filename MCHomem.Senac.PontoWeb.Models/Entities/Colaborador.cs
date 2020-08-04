using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCHomem.Senac.PontoWeb.Models.Entities
{
    [Serializable]
    public class Colaborador
    {
        #region Properties

        [Column(TypeName = "nvarchar(50)")]
        public Guid? ID { get; set; }

        public String Nome { get; set; }

        [JsonIgnore]
        public ICollection<Ponto> Pontos { get; set; }

        #endregion
    }
}
