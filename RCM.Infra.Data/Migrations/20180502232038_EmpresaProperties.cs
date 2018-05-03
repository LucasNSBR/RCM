using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class EmpresaProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Empresa",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AddColumn<string>(
                name: "ContatoCelular",
                table: "Empresa",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmail",
                table: "Empresa",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoObservacao",
                table: "Empresa",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoTelefoneComercial",
                table: "Empresa",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoTelefoneResidencial",
                table: "Empresa",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoBairro",
                table: "Empresa",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoCEP",
                table: "Empresa",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoComplemento",
                table: "Empresa",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoNumero",
                table: "Empresa",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EnderecoRua",
                table: "Empresa",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContatoCelular",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ContatoEmail",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ContatoObservacao",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ContatoTelefoneComercial",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ContatoTelefoneResidencial",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EnderecoBairro",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EnderecoCEP",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EnderecoComplemento",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EnderecoNumero",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EnderecoRua",
                table: "Empresa");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Empresa",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
