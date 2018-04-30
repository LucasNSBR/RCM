using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class EnderecoValueObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Clientes_ClienteId",
                table: "Cheques");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidades_CidadeId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdensServico_Clientes_ClienteId",
                table: "OrdensServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_CidadeId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Rua",
                table: "Clientes",
                newName: "EnderecoRua");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Clientes",
                newName: "EnderecoNumero");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Clientes",
                newName: "EnderecoComplemento");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Clientes",
                newName: "EnderecoCEP");

            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Clientes",
                newName: "EnderecoBairro");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoComplemento",
                table: "Clientes",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoCEP",
                table: "Clientes",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Clientes",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Clientes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContatoCelular",
                table: "Clientes",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmail",
                table: "Clientes",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoObservacao",
                table: "Clientes",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoTelefoneComercial",
                table: "Clientes",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContatoTelefoneResidencial",
                table: "Clientes",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Clientes_ClienteId",
                table: "Cheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdensServico_Clientes_ClienteId",
                table: "OrdensServico",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheques_Clientes_ClienteId",
                table: "Cheques");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdensServico_Clientes_ClienteId",
                table: "OrdensServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ContatoCelular",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ContatoEmail",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ContatoObservacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ContatoTelefoneComercial",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ContatoTelefoneResidencial",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "EnderecoRua",
                table: "Enderecos",
                newName: "Rua");

            migrationBuilder.RenameColumn(
                name: "EnderecoNumero",
                table: "Enderecos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "EnderecoComplemento",
                table: "Enderecos",
                newName: "Complemento");

            migrationBuilder.RenameColumn(
                name: "EnderecoCEP",
                table: "Enderecos",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "EnderecoBairro",
                table: "Enderecos",
                newName: "Bairro");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Enderecos",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CidadeId",
                table: "Enderecos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Enderecos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Celular = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    ContatoObservacao = table.Column<string>(maxLength: 250, nullable: true),
                    TelefoneComercial = table.Column<string>(maxLength: 15, nullable: true),
                    TelefoneResidencial = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_CidadeId",
                table: "Enderecos",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheques_Clientes_ClienteId",
                table: "Cheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Cidades_CidadeId",
                table: "Enderecos",
                column: "CidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdensServico_Clientes_ClienteId",
                table: "OrdensServico",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
