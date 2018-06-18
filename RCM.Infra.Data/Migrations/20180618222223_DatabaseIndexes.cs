using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DatabaseIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ReferenciaAuxiliar",
                table: "Produtos",
                column: "ReferenciaAuxiliar");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ReferenciaFabricante",
                table: "Produtos",
                column: "ReferenciaFabricante");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ReferenciaOriginal",
                table: "Produtos",
                column: "ReferenciaOriginal");

            migrationBuilder.CreateIndex(
                name: "IX_Duplicatas_NumeroDocumento",
                table: "Duplicatas",
                column: "NumeroDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_NumeroCheque",
                table: "Cheques",
                column: "NumeroCheque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produtos_ReferenciaAuxiliar",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ReferenciaFabricante",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ReferenciaOriginal",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Duplicatas_NumeroDocumento",
                table: "Duplicatas");

            migrationBuilder.DropIndex(
                name: "IX_Cheques_NumeroCheque",
                table: "Cheques");
        }
    }
}
