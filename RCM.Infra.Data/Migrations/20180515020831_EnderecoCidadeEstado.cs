using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class EnderecoCidadeEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Endereco_CidadeId",
                table: "Fornecedores",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estados",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "Estados",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Endereco_CidadeId",
                table: "Empresa",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Endereco_CidadeId",
                table: "Clientes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Endereco_CidadeId",
                table: "Fornecedores",
                column: "Endereco_CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Endereco_CidadeId",
                table: "Empresa",
                column: "Endereco_CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Endereco_CidadeId",
                table: "Clientes",
                column: "Endereco_CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Cidades_Endereco_CidadeId",
                table: "Clientes",
                column: "Endereco_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Cidades_Endereco_CidadeId",
                table: "Empresa",
                column: "Endereco_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Cidades_Endereco_CidadeId",
                table: "Fornecedores",
                column: "Endereco_CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Cidades_Endereco_CidadeId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Cidades_Endereco_CidadeId",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Cidades_Endereco_CidadeId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_Endereco_CidadeId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_Endereco_CidadeId",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Endereco_CidadeId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco_CidadeId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "Endereco_CidadeId",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Endereco_CidadeId",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Estados",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}
