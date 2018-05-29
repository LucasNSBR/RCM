using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DuplicataNotaFiscalMaxLengthSix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaFiscal",
                table: "Duplicatas");

            migrationBuilder.AddColumn<string>(
                name: "NotaFiscalId",
                table: "Duplicatas",
                maxLength: 6,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Duplicatas");

            migrationBuilder.AddColumn<string>(
                name: "NotaFiscal",
                table: "Duplicatas",
                nullable: true);
        }
    }
}
