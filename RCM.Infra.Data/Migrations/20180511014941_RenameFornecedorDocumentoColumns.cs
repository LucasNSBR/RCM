using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RCM.Infra.Data.Migrations
{
    public partial class RenameFornecedorDocumentoColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Fornecedores",
                newName: "DocumentoNacional");

            migrationBuilder.RenameColumn(
                name: "InscricaoEstadual",
                table: "Fornecedores",
                newName: "DocumentoEstadual");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentoNacional",
                table: "Fornecedores",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "DocumentoEstadual",
                table: "Fornecedores",
                newName: "InscricaoEstadual");
        }
    }
}
