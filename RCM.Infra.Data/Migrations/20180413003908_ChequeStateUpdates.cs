using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ChequeStateUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "EstadosCheques");

            migrationBuilder.RenameColumn(
                name: "ChequeSustado_Motivo",
                table: "EstadosCheques",
                newName: "Motivo");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "EstadosCheques",
                newName: "DataEvento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Motivo",
                table: "EstadosCheques",
                newName: "ChequeSustado_Motivo");

            migrationBuilder.RenameColumn(
                name: "DataEvento",
                table: "EstadosCheques",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "EstadosCheques",
                nullable: true);
        }
    }
}
