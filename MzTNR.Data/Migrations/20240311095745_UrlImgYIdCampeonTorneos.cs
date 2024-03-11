using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MzTNR.Data.Migrations
{
    /// <inheritdoc />
    public partial class UrlImgYIdCampeonTorneos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCampeon",
                table: "Torneos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagen",
                table: "Torneos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCampeon",
                table: "Torneos");

            migrationBuilder.DropColumn(
                name: "UrlImagen",
                table: "Torneos");
        }
    }
}
