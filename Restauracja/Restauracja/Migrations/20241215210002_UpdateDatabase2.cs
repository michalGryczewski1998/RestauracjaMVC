using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdresRestauracji_restauracjas_RestauracjaId",
                table: "AdresRestauracji");

            migrationBuilder.DropForeignKey(
                name: "FK_DaneKontaktoweRestauracji_restauracjas_RestauracjaId",
                table: "DaneKontaktoweRestauracji");

            migrationBuilder.DropForeignKey(
                name: "FK_DaniaRestauracji_restauracjas_RestauracjaID",
                table: "DaniaRestauracji");

            migrationBuilder.DropPrimaryKey(
                name: "PK_restauracjas",
                table: "restauracjas");

            migrationBuilder.RenameTable(
                name: "restauracjas",
                newName: "Restauracjas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restauracjas",
                table: "Restauracjas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AplikacjaInformacje",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WersjaAplikacji = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataWersji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NazwaAplikacji = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikacjaInformacje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParametryKonfiguracyjne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CzyWlaczone = table.Column<bool>(type: "bit", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataWlaczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametryKonfiguracyjne", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdresRestauracji_Restauracjas_RestauracjaId",
                table: "AdresRestauracji",
                column: "RestauracjaId",
                principalTable: "Restauracjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaneKontaktoweRestauracji_Restauracjas_RestauracjaId",
                table: "DaneKontaktoweRestauracji",
                column: "RestauracjaId",
                principalTable: "Restauracjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaRestauracji_Restauracjas_RestauracjaID",
                table: "DaniaRestauracji",
                column: "RestauracjaID",
                principalTable: "Restauracjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdresRestauracji_Restauracjas_RestauracjaId",
                table: "AdresRestauracji");

            migrationBuilder.DropForeignKey(
                name: "FK_DaneKontaktoweRestauracji_Restauracjas_RestauracjaId",
                table: "DaneKontaktoweRestauracji");

            migrationBuilder.DropForeignKey(
                name: "FK_DaniaRestauracji_Restauracjas_RestauracjaID",
                table: "DaniaRestauracji");

            migrationBuilder.DropTable(
                name: "AplikacjaInformacje");

            migrationBuilder.DropTable(
                name: "ParametryKonfiguracyjne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restauracjas",
                table: "Restauracjas");

            migrationBuilder.RenameTable(
                name: "Restauracjas",
                newName: "restauracjas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_restauracjas",
                table: "restauracjas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdresRestauracji_restauracjas_RestauracjaId",
                table: "AdresRestauracji",
                column: "RestauracjaId",
                principalTable: "restauracjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaneKontaktoweRestauracji_restauracjas_RestauracjaId",
                table: "DaneKontaktoweRestauracji",
                column: "RestauracjaId",
                principalTable: "restauracjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaniaRestauracji_restauracjas_RestauracjaID",
                table: "DaniaRestauracji",
                column: "RestauracjaID",
                principalTable: "restauracjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
