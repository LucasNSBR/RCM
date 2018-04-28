using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class RemoveBrokenProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Duplicatas");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Duplicatas");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Duplicatas");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Cheques");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Bancos");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Bancos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Bancos");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Aplicacoes");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Aplicacoes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Aplicacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Vendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Vendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Vendas",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Produtos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Produtos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Produtos",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrdensServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "OrdensServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "OrdensServico",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "NotasFiscais",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "NotasFiscais",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotasFiscais",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Marcas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Marcas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Marcas",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Fornecedores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Fornecedores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Fornecedores",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Estados",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Estados",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Estados",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Enderecos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Enderecos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Enderecos",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Duplicatas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Duplicatas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Duplicatas",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Contatos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Contatos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Contatos",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Clientes",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cidades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cidades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Cidades",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cheques",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cheques",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Cheques",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Bancos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Bancos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Bancos",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Aplicacoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Aplicacoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Aplicacoes",
                rowVersion: true,
                nullable: true);
        }
    }
}
