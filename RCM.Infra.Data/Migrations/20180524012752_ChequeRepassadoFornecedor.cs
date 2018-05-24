using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ChequeRepassadoFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "EstadosCheques",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_EstadosCheques_ClienteId",
                table: "EstadosCheques",
                newName: "IX_EstadosCheques_FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosCheques_Fornecedores_FornecedorId",
                table: "EstadosCheques",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadosCheques_Fornecedores_FornecedorId",
                table: "EstadosCheques");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "EstadosCheques",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_EstadosCheques_FornecedorId",
                table: "EstadosCheques",
                newName: "IX_EstadosCheques_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
