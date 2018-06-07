using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class AnoCarroNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoNacional",
                table: "Clientes",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Clientes",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<int>(
                name: "CarroAno",
                table: "Aplicacoes",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InscricaoEstadual",
                table: "Empresa",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoNacional",
                table: "Clientes",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Clientes",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarroAno",
                table: "Aplicacoes",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 4,
                oldNullable: true);
        }
    }
}
