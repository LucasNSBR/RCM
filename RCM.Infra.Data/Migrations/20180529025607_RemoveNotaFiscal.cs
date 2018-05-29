using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class RemoveNotaFiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duplicatas_NotasFiscais_NotaFiscalId",
                table: "Duplicatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_NotasFiscais_NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Duplicatas_NotaFiscalId",
                table: "Duplicatas");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Duplicatas");

            migrationBuilder.AddColumn<string>(
                name: "NotaFiscal",
                table: "Duplicatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaFiscal",
                table: "Duplicatas");

            migrationBuilder.AddColumn<Guid>(
                name: "NotaFiscalId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NotaFiscalId",
                table: "Duplicatas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataChegada = table.Column<DateTime>(nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    FornecedorId = table.Column<Guid>(nullable: true),
                    NumeroDocumento = table.Column<string>(maxLength: 6, nullable: false),
                    Valor = table.Column<decimal>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Duplicatas_NotaFiscalId",
                table: "Duplicatas",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_FornecedorId",
                table: "NotasFiscais",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duplicatas_NotasFiscais_NotaFiscalId",
                table: "Duplicatas",
                column: "NotaFiscalId",
                principalTable: "NotasFiscais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_NotasFiscais_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId",
                principalTable: "NotasFiscais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
