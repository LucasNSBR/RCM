using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class CidadeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Cidades_Endereco_CidadeId",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Cidades_Endereco_CidadeId",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "Endereco_CidadeId",
                table: "Fornecedores",
                newName: "EnderecoCidadeId");

            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Fornecedores",
                newName: "Descricao");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_Endereco_CidadeId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_EnderecoCidadeId");

            migrationBuilder.RenameColumn(
                name: "Endereco_CidadeId",
                table: "Empresa",
                newName: "EnderecoCidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Empresa_Endereco_CidadeId",
                table: "Empresa",
                newName: "IX_Empresa_EnderecoCidadeId");

            migrationBuilder.RenameColumn(
                name: "Motor",
                table: "Aplicacoes",
                newName: "CarroMotor");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Aplicacoes",
                newName: "CarroModelo");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Aplicacoes",
                newName: "CarroMarca");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Aplicacoes",
                newName: "CarroAno");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Fornecedores",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Conta",
                table: "Cheques",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Cidades_EnderecoCidadeId",
                table: "Empresa",
                column: "EnderecoCidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Cidades_EnderecoCidadeId",
                table: "Fornecedores",
                column: "EnderecoCidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Cidades_EnderecoCidadeId",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Cidades_EnderecoCidadeId",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "EnderecoCidadeId",
                table: "Fornecedores",
                newName: "Endereco_CidadeId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Fornecedores",
                newName: "Observacao");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_EnderecoCidadeId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_Endereco_CidadeId");

            migrationBuilder.RenameColumn(
                name: "EnderecoCidadeId",
                table: "Empresa",
                newName: "Endereco_CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Empresa_EnderecoCidadeId",
                table: "Empresa",
                newName: "IX_Empresa_Endereco_CidadeId");

            migrationBuilder.RenameColumn(
                name: "CarroMotor",
                table: "Aplicacoes",
                newName: "Motor");

            migrationBuilder.RenameColumn(
                name: "CarroModelo",
                table: "Aplicacoes",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "CarroMarca",
                table: "Aplicacoes",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "CarroAno",
                table: "Aplicacoes",
                newName: "Ano");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Fornecedores",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Conta",
                table: "Cheques",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

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
    }
}
