using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ProdutoAplicacaoUpdateColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Carro_Observacao",
                table: "Aplicacoes",
                newName: "Observacao");

            migrationBuilder.RenameColumn(
                name: "Carro_Motor",
                table: "Aplicacoes",
                newName: "Motor");

            migrationBuilder.RenameColumn(
                name: "Carro_Modelo",
                table: "Aplicacoes",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Carro_Marca",
                table: "Aplicacoes",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "Carro_Ano",
                table: "Aplicacoes",
                newName: "Ano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Aplicacoes",
                newName: "Carro_Observacao");

            migrationBuilder.RenameColumn(
                name: "Motor",
                table: "Aplicacoes",
                newName: "Carro_Motor");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Aplicacoes",
                newName: "Carro_Modelo");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Aplicacoes",
                newName: "Carro_Marca");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Aplicacoes",
                newName: "Carro_Ano");
        }
    }
}
