using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restauracjas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    TypLokalu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypRestauracji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyDriveThru = table.Column<bool>(type: "bit", nullable: false),
                    CzyDostawa = table.Column<bool>(type: "bit", nullable: false),
                    CzyParkinPrzyRestauracji = table.Column<bool>(type: "bit", nullable: false),
                    CzyMozliwaRezerwacja = table.Column<bool>(type: "bit", nullable: false),
                    CzyImprezyOkolicznosciowe = table.Column<bool>(type: "bit", nullable: false),
                    CzySalaOkolicznosciowa = table.Column<bool>(type: "bit", nullable: false),
                    GodzinaOtwarcia = table.Column<TimeSpan>(type: "time", nullable: false),
                    GodzinaZamkniecia = table.Column<TimeSpan>(type: "time", nullable: false),
                    CzasOtwarcia = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restauracjas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "restauracjas");
        }
    }
}
