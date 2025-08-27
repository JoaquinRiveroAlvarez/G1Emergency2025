using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G1Emergency2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class FinalTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Tripulantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "TripulacionActuals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "TipoTripulantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "TipoMovil",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "TipoEstados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Rols",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Moviles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "LugarHechos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Historicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "DiagPresuntivos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Causas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Tripulantes");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "TripulacionActuals");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "TipoTripulantes");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "TipoMovil");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "TipoEstados");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Rols");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Moviles");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "LugarHechos");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Historicos");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "DiagPresuntivos");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Causas");
        }
    }
}
