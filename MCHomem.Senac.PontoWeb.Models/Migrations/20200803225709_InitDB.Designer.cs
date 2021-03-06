﻿// <auto-generated />
using System;
using MCHomem.Senac.PontoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCHomem.Senac.PontoWeb.Models.Migrations
{
    [DbContext(typeof(PontoContext))]
    [Migration("20200803225709_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MCHomem.Senac.PontoWeb.Models.Entities.Colaborador", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("MCHomem.Senac.PontoWeb.Models.Entities.Ponto", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColaboradorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset?>("DataHoraRegistroPonto")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IndicadorEntradaSaida")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(1);

                    b.HasKey("ID");

                    b.HasIndex("ColaboradorID");

                    b.ToTable("Ponto");
                });

            modelBuilder.Entity("MCHomem.Senac.PontoWeb.Models.Entities.Ponto", b =>
                {
                    b.HasOne("MCHomem.Senac.PontoWeb.Models.Entities.Colaborador", "Colaborador")
                        .WithMany("Pontos")
                        .HasForeignKey("ColaboradorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
