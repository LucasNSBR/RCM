using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class NotRequiredDuplicataNF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duplicatas_NotasFiscais_NotaFiscalId",
                table: "Duplicatas");

            migrationBuilder.AlterColumn<Guid>(
                name: "NotaFiscalId",
                table: "Duplicatas",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Duplicatas_NotasFiscais_NotaFiscalId",
                table: "Duplicatas",
                column: "NotaFiscalId",
                principalTable: "NotasFiscais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duplicatas_NotasFiscais_NotaFiscalId",
                table: "Duplicatas");

            migrationBuilder.AlterColumn<Guid>(
                name: "NotaFiscalId",
                table: "Duplicatas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Duplicatas_NotasFiscais_NotaFiscalId",
                table: "Duplicatas",
                column: "NotaFiscalId",
                principalTable: "NotasFiscais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
