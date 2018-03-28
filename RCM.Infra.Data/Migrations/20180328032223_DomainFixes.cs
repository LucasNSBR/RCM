using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DomainFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Produtos_ProdutoId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasFiscais_NotasFiscais_NotaFiscalId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_NotasFiscais_NotaFiscalId",
                table: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_ProdutoId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "NotasFiscais");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Fornecedores");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Vendas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NotaFiscalId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "OrdensServico",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_NotasFiscais_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId",
                principalTable: "NotasFiscais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_NotasFiscais_NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "OrdensServico");

            migrationBuilder.AddColumn<int>(
                name: "NotaFiscalId",
                table: "NotasFiscais",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_NotaFiscalId",
                table: "NotasFiscais",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_ProdutoId",
                table: "Fornecedores",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Produtos_ProdutoId",
                table: "Fornecedores",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotasFiscais_NotasFiscais_NotaFiscalId",
                table: "NotasFiscais",
                column: "NotaFiscalId",
                principalTable: "NotasFiscais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
