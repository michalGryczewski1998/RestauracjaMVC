using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Migrations
{
    /// <inheritdoc />
    public partial class DodanieWartKonf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyWypelnioneDaneAdres",
                table: "Restauracjas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CzyWypelnioneDaneDan",
                table: "Restauracjas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyWypelnioneDaneAdres",
                table: "Restauracjas");

            migrationBuilder.DropColumn(
                name: "CzyWypelnioneDaneDan",
                table: "Restauracjas");
        }
    }
}
