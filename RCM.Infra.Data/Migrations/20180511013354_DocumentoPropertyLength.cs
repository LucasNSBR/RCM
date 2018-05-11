using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DocumentoPropertyLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentoNacional",
                table: "Clientes",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Clientes",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentoNacional",
                table: "Clientes",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Clientes",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
