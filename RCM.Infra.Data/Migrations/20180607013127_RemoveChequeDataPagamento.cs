using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class RemoveChequeDataPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Cheques");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Cheques",
                nullable: true);
        }
    }
}
