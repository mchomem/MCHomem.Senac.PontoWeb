using MCHomem.Senac.PontoWeb.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MCHomem.Senac.PontoWeb.Models.Maps
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        #region Method using Fluent API

        public void Configure(EntityTypeBuilder<Colaborador> modelBuilder)
        {
            modelBuilder
                .ToTable("Colaborador");

            modelBuilder
                .HasKey(x => x.ID);

            modelBuilder
                .Property<String>(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
        }

        #endregion
    }
}
