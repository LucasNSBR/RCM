using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DuplicataPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Duplicatas");

            migrationBuilder.RenameColumn(
                name: "ValorPago",
                table: "Duplicatas",
                newName: "Pagamento_ValorPago");

            migrationBuilder.RenameColumn(
                name: "DataPagamento",
                table: "Duplicatas",
                newName: "Pagamento_DataPagamento");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pagamento_ValorPago",
                table: "Duplicatas",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Pagamento_DataPagamento",
                table: "Duplicatas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pagamento_ValorPago",
                table: "Duplicatas",
                newName: "ValorPago");

            migrationBuilder.RenameColumn(
                name: "Pagamento_DataPagamento",
                table: "Duplicatas",
                newName: "DataPagamento");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPago",
                table: "Duplicatas",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Duplicatas",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Duplicatas",
                nullable: false,
                defaultValue: false);
        }
    }
}
