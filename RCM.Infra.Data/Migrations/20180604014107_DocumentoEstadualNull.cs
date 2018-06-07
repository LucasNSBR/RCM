using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DocumentoEstadualNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Fornecedores",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentoEstadual",
                table: "Fornecedores",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);
        }
    }
}
