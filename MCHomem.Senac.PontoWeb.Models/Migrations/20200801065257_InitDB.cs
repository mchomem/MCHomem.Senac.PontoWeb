using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MCHomem.Senac.PontoWeb.Models.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ponto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorID = table.Column<string>(nullable: false),
                    DataHoraRegistroPonto = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IndicadorEntradaSaida = table.Column<string>(type: "nvarchar", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ponto_Colaborador_ColaboradorID",
                        column: x => x.ColaboradorID,
                        principalTable: "Colaborador",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ponto_ColaboradorID",
                table: "Ponto",
                column: "ColaboradorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ponto");

            migrationBuilder.DropTable(
                name: "Colaborador");
        }
    }
}
