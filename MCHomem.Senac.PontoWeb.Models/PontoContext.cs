using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace MCHomem.Senac.PontoWeb.Models
{
    public class PontoContext : DbContext
    {
        #region Constructors

        public PontoContext(DbContextOptions<PontoContext> options) : base(options) { }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new PontoMap());
        }

        #endregion

        #region Properties

        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Ponto> Ponto { get; set; }

        #endregion
    }
}
