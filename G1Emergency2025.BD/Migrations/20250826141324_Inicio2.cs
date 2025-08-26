using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G1Emergency2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tripulantes_Personas_PersonaId",
                table: "Tripulantes");

            migrationBuilder.DropIndex(
                name: "IX_Tripulantes_PersonaId",
                table: "Tripulantes");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Tripulantes");

            migrationBuilder.AlterColumn<bool>(
                name: "EnMovil",
                table: "Tripulantes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TripulanteId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TripulanteId",
                table: "Personas",
                column: "TripulanteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Tripulantes_TripulanteId",
                table: "Personas",
                column: "TripulanteId",
                principalTable: "Tripulantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Tripulantes_TripulanteId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TripulanteId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TripulanteId",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "EnMovil",
                table: "Tripulantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Tripulantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tripulantes_PersonaId",
                table: "Tripulantes",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulantes_Personas_PersonaId",
                table: "Tripulantes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
