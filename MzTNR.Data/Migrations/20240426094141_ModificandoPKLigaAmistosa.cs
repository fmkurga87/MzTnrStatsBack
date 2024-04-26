using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MzTNR.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoPKLigaAmistosa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigasAmistosas_Torneos_TorneoId",
                table: "LigasAmistosas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LigasAmistosas",
                table: "LigasAmistosas");

            migrationBuilder.DropIndex(
                name: "IX_LigasAmistosas_TorneoId",
                table: "LigasAmistosas");

            migrationBuilder.DropColumn(
                name: "TorneoId",
                table: "LigasAmistosas");

            migrationBuilder.AddColumn<int>(
                name: "LigasAmistosasIdMz",
                table: "Torneos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LigasAmistosasPosicion",
                table: "Torneos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdMz",
                table: "LigasAmistosas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LigasAmistosas",
                table: "LigasAmistosas",
                columns: new[] { "IdMz", "Posicion" });

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_LigasAmistosasIdMz_LigasAmistosasPosicion",
                table: "Torneos",
                columns: new[] { "LigasAmistosasIdMz", "LigasAmistosasPosicion" });

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos_LigasAmistosas_LigasAmistosasIdMz_LigasAmistosasPosi~",
                table: "Torneos",
                columns: new[] { "LigasAmistosasIdMz", "LigasAmistosasPosicion" },
                principalTable: "LigasAmistosas",
                principalColumns: new[] { "IdMz", "Posicion" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torneos_LigasAmistosas_LigasAmistosasIdMz_LigasAmistosasPosi~",
                table: "Torneos");

            migrationBuilder.DropIndex(
                name: "IX_Torneos_LigasAmistosasIdMz_LigasAmistosasPosicion",
                table: "Torneos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LigasAmistosas",
                table: "LigasAmistosas");

            migrationBuilder.DropColumn(
                name: "LigasAmistosasIdMz",
                table: "Torneos");

            migrationBuilder.DropColumn(
                name: "LigasAmistosasPosicion",
                table: "Torneos");

            migrationBuilder.AlterColumn<int>(
                name: "IdMz",
                table: "LigasAmistosas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "TorneoId",
                table: "LigasAmistosas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LigasAmistosas",
                table: "LigasAmistosas",
                column: "IdMz");

            migrationBuilder.CreateIndex(
                name: "IX_LigasAmistosas_TorneoId",
                table: "LigasAmistosas",
                column: "TorneoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LigasAmistosas_Torneos_TorneoId",
                table: "LigasAmistosas",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "IdMz");
        }
    }
}
