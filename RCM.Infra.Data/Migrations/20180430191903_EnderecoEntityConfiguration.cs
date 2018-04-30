using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class EnderecoEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Fornecedores",
                newName: "ContatoObservacao");

            migrationBuilder.AlterColumn<string>(
                name: "ContatoObservacao",
                table: "Fornecedores",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Fornecedores",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoCelular",
                table: "Fornecedores",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmail",
                table: "Fornecedores",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoTelefoneComercial",
                table: "Fornecedores",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoTelefoneResidencial",
                table: "Fornecedores",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoBairro",
                table: "Fornecedores",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCEP",
                table: "Fornecedores",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoComplemento",
                table: "Fornecedores",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoNumero",
                table: "Fornecedores",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoRua",
                table: "Fornecedores",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ContatoCelular",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ContatoEmail",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ContatoTelefoneComercial",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ContatoTelefoneResidencial",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoBairro",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoCEP",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoComplemento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoNumero",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "EnderecoRua",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "ContatoObservacao",
                table: "Fornecedores",
                newName: "Observacao");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Fornecedores",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
