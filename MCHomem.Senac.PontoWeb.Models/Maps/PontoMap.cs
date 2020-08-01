﻿using MCHomem.Senac.PontoWeb.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCHomem.Senac.PontoWeb.Models.Maps
{
    public class PontoMap : IEntityTypeConfiguration<Ponto>
    {
        #region Method using Fluent API

        public void Configure(EntityTypeBuilder<Ponto> modelBuilder)
        {
            modelBuilder
                .ToTable("Ponto");

            modelBuilder
                .HasKey(x => x.ID);

            modelBuilder
                .Property(x => x.DataHoraRegistroPonto)
                .HasColumnType("datetimeoffset")
                .IsRequired();

            modelBuilder
                .Property(x => x.IndicadorEntradaSaida)
                .HasColumnType("nvarchar")
                .HasMaxLength(1)
                .IsRequired();
        }

        #endregion
    }
}
