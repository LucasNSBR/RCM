using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ProdutoMarcaFKFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoMarca_Produtos_MarcaId",
                table: "ProdutoMarca");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoMarca_Marcas_ProdutoId",
                table: "ProdutoMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoMarca_Marcas_MarcaId",
                table: "ProdutoMarca",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoMarca_Produtos_ProdutoId",
                table: "ProdutoMarca",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoMarca_Marcas_MarcaId",
                table: "ProdutoMarca");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoMarca_Produtos_ProdutoId",
                table: "ProdutoMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoMarca_Produtos_MarcaId",
                table: "ProdutoMarca",
                column: "MarcaId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoMarca_Marcas_ProdutoId",
                table: "ProdutoMarca",
                column: "ProdutoId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
