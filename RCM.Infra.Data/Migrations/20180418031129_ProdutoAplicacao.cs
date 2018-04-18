using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ProdutoAplicacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aplicacao",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Carro_Ano = table.Column<int>(nullable: false),
                    Carro_Marca = table.Column<string>(nullable: true),
                    Carro_Modelo = table.Column<string>(nullable: true),
                    Carro_Motor = table.Column<string>(nullable: true),
                    Carro_Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoAplicacao",
                columns: table => new
                {
                    AplicacaoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoAplicacao", x => new { x.AplicacaoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutoAplicacao_Aplicacoes_AplicacaoId",
                        column: x => x.AplicacaoId,
                        principalTable: "Aplicacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoAplicacao_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoAplicacao_ProdutoId",
                table: "ProdutoAplicacao",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoAplicacao");

            migrationBuilder.DropTable(
                name: "Aplicacoes");

            migrationBuilder.AddColumn<string>(
                name: "Aplicacao",
                table: "Produtos",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
