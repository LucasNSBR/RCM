using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class ClienteTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "DocumentoNacional");

            migrationBuilder.RenameColumn(
                name: "RG",
                table: "Clientes",
                newName: "DocumentoEstadual");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "DocumentoNacional",
                table: "Clientes",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "DocumentoEstadual",
                table: "Clientes",
                newName: "RG");
        }
    }
}
