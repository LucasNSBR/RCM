using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class MotorRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_OrdensServico_OrdemServicoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "OrdensServico");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrdemServicoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrdemServicoId",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "CarroMotor",
                table: "Aplicacoes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrdemServicoId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarroMotor",
                table: "Aplicacoes",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "OrdensServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdensServico_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrdemServicoId",
                table: "Produtos",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_ClienteId",
                table: "OrdensServico",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_OrdensServico_OrdemServicoId",
                table: "Produtos",
                column: "OrdemServicoId",
                principalTable: "OrdensServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
