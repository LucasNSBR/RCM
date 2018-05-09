using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class VendaQuantidadeProdutosTotalVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeProdutos",
                table: "Vendas",
                maxLength: 2,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalVenda",
                table: "Vendas",
                maxLength: 5,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoFinal",
                table: "VendaProduto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoVenda",
                table: "VendaProduto",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Fornecedores",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeProdutos",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "TotalVenda",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "PrecoFinal",
                table: "VendaProduto");

            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "VendaProduto");

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Fornecedores",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11);
        }
    }
}
