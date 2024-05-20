using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MzTNR.Data.Migrations
{
    /// <inheritdoc />
    public partial class GrupoCopa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FasesGrupos_Equipos_EquipoId",
                table: "FasesGrupos");

            migrationBuilder.DropForeignKey(
                name: "FK_FasesGrupos_Torneos_TorneoId",
                table: "FasesGrupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos");

            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "FasesGrupos");

            migrationBuilder.DropColumn(
                name: "GolesAFavor",
                table: "FasesGrupos");

            migrationBuilder.DropColumn(
                name: "GolesEnContra",
                table: "FasesGrupos");

            migrationBuilder.DropColumn(
                name: "PartidosEmpatados",
                table: "FasesGrupos");

            migrationBuilder.DropColumn(
                name: "PartidosGanados",
                table: "FasesGrupos");

            migrationBuilder.DropColumn(
                name: "PartidosPerdidos",
                table: "FasesGrupos");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoId",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos",
                columns: new[] { "TorneoId", "Grupo", "EquipoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FasesGrupos_Equipos_EquipoId",
                table: "FasesGrupos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "IdMz",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FasesGrupos_Equipos_EquipoId",
                table: "FasesGrupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoId",
                table: "FasesGrupos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Posicion",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolesAFavor",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolesEnContra",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosEmpatados",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosGanados",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidosPerdidos",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos",
                columns: new[] { "TorneoId", "Grupo", "Posicion" });

            migrationBuilder.AddForeignKey(
                name: "FK_FasesGrupos_Equipos_EquipoId",
                table: "FasesGrupos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "IdMz");

            migrationBuilder.AddForeignKey(
                name: "FK_FasesGrupos_Torneos_TorneoId",
                table: "FasesGrupos",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "IdMz",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
