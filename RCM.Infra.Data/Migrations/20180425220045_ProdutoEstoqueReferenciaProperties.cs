using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ProdutoEstoqueReferenciaProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "EstoqueMinimo");

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Produtos",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstoqueIdeal",
                table: "Produtos",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaAuxiliar",
                table: "Produtos",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaFabricante",
                table: "Produtos",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaOriginal",
                table: "Produtos",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Conta",
                table: "Cheques",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Aplicacoes",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Motor",
                table: "Aplicacoes",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EstoqueIdeal",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ReferenciaAuxiliar",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ReferenciaFabricante",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ReferenciaOriginal",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "EstoqueMinimo",
                table: "Produtos",
                newName: "Quantidade");

            migrationBuilder.AlterColumn<string>(
                name: "Conta",
                table: "Cheques",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Aplicacoes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Motor",
                table: "Aplicacoes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
