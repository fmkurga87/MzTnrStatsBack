using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MzTNR.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoCopaFKTorneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_FasesGrupos_Torneos_TorneoId",
                table: "FasesGrupos",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "IdMz",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FasesGrupos_Torneos_TorneoId",
                table: "FasesGrupos");
        }
    }
}
