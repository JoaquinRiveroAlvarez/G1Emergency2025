using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G1Emergency2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class Persona1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "TipoMovilId",
                table: "Movils",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movils_TipoMovilId",
                table: "Movils",
                column: "TipoMovilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movils_TipoMovil_TipoMovilId",
                table: "Movils",
                column: "TipoMovilId",
                principalTable: "TipoMovil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movils_TipoMovil_TipoMovilId",
                table: "Movils");

            migrationBuilder.DropIndex(
                name: "IX_Movils_TipoMovilId",
                table: "Movils");

            migrationBuilder.DropColumn(
                name: "TipoMovilId",
                table: "Movils");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
