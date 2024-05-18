using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MzTNR.Data.Migrations
{
    /// <inheritdoc />
    public partial class PkGruposCopa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FasesGrupos_Torneos_TorneoId",
                table: "FasesGrupos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos");

            migrationBuilder.AlterColumn<int>(
                name: "TorneoId",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "FasesGrupos",
                keyColumn: "Grupo",
                keyValue: null,
                column: "Grupo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Grupo",
                table: "FasesGrupos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos",
                columns: new[] { "TorneoId", "Grupo", "Posicion" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FasesGrupos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Grupo",
                table: "FasesGrupos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "TorneoId",
                table: "FasesGrupos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FasesGrupos",
                table: "FasesGrupos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FasesGrupos_Torneos_TorneoId",
                table: "FasesGrupos",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "IdMz");
        }
    }
}
