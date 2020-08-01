using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCHomem.Senac.PontoWeb.Models.Entities
{
    [Serializable]
    public class Colaborador
    {
        #region Properties

        [Column(TypeName = "nvarchar(50)")]
        public Guid? ID { get; set; }

        public String Nome { get; set; }

        #endregion
    }
}
