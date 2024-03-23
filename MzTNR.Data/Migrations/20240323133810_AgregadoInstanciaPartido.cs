﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MzTNR.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoInstanciaPartido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Instancia",
                table: "Partidos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instancia",
                table: "Partidos");
        }
    }
}
