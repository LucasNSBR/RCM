using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class RenameParcelamentoToCondicaoPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParcelamentoObject",
                table: "Vendas",
                newName: "CondicaoPagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CondicaoPagamento",
                table: "Vendas",
                newName: "ParcelamentoObject");
        }
    }
}
