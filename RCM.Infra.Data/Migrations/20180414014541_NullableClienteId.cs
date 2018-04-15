using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class NullableClienteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadosCheques_Clientes_ClienteId",
                table: "EstadosCheques",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
