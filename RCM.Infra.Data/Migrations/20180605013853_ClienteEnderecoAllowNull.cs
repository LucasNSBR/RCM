using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ClienteEnderecoAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EnderecoRua",
                table: "Clientes",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoNumero",
                table: "Clientes",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoBairro",
                table: "Clientes",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EnderecoRua",
                table: "Clientes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoNumero",
                table: "Clientes",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoBairro",
                table: "Clientes",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}
