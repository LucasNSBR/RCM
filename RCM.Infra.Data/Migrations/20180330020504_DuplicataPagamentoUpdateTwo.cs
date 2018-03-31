using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class DuplicataPagamentoUpdateTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pagamento_ValorPago",
                table: "Duplicatas",
                newName: "ValorPago");

            migrationBuilder.RenameColumn(
                name: "Pagamento_DataPagamento",
                table: "Duplicatas",
                newName: "DataPagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorPago",
                table: "Duplicatas",
                newName: "Pagamento_ValorPago");

            migrationBuilder.RenameColumn(
                name: "DataPagamento",
                table: "Duplicatas",
                newName: "Pagamento_DataPagamento");
        }
    }
}
