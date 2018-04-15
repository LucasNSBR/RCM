using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ChequeState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCheques",
                columns: table => new
                {
                    Motivo = table.Column<string>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true),
                    ChequeSustado_Motivo = table.Column<string>(nullable: true),
                    ChequeId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCheques", x => x.ChequeId);
                    table.ForeignKey(
                        name: "FK_EstadosCheques_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EstadosCheques_Cheques_ChequeId",
                        column: x => x.ChequeId,
                        principalTable: "Cheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadosCheques_ClienteId",
                table: "EstadosCheques",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosCheques");
        }
    }
}
