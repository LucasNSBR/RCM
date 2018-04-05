using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class OrdemServicoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "OrdensServico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaida",
                table: "OrdensServico",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrdensServico",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "DataSaida",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrdensServico");
        }
    }
}
