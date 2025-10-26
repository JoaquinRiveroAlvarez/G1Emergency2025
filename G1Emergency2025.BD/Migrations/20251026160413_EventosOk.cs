using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G1Emergency2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class EventosOk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Personas_PersonaId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tripulantes_Personas_PersonaId",
                table: "Tripulantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Personas_PersonaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "Persona");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersona",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Persona_PersonaId",
                table: "Pacientes",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulantes_Persona_PersonaId",
                table: "Tripulantes",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Persona_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Persona_PersonaId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tripulantes_Persona_PersonaId",
                table: "Tripulantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Persona_PersonaId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "NombrePersona",
                table: "Pacientes");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Personas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Personas_PersonaId",
                table: "Pacientes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulantes_Personas_PersonaId",
                table: "Tripulantes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Personas_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
