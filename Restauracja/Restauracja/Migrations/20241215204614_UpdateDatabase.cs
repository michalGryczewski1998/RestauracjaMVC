using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauracja.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdresRestauracji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejscowosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<int>(type: "int", nullable: false),
                    Ulica = table.Column<int>(type: "int", nullable: false),
                    NumerDomu = table.Column<int>(type: "int", nullable: false),
                    RestauracjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresRestauracji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdresRestauracji_restauracjas_RestauracjaId",
                        column: x => x.RestauracjaId,
                        principalTable: "restauracjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaneKontaktoweRestauracji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StronaInternetowa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestauracjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneKontaktoweRestauracji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaneKontaktoweRestauracji_restauracjas_RestauracjaId",
                        column: x => x.RestauracjaId,
                        principalTable: "restauracjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaniaRestauracji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zdjecie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kalorycznosc = table.Column<int>(type: "int", nullable: false),
                    Informacje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestauracjaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaniaRestauracji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaniaRestauracji_restauracjas_RestauracjaID",
                        column: x => x.RestauracjaID,
                        principalTable: "restauracjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdresRestauracji_RestauracjaId",
                table: "AdresRestauracji",
                column: "RestauracjaId");

            migrationBuilder.CreateIndex(
                name: "IX_DaneKontaktoweRestauracji_RestauracjaId",
                table: "DaneKontaktoweRestauracji",
                column: "RestauracjaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaniaRestauracji_RestauracjaID",
                table: "DaniaRestauracji",
                column: "RestauracjaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresRestauracji");

            migrationBuilder.DropTable(
                name: "DaneKontaktoweRestauracji");

            migrationBuilder.DropTable(
                name: "DaniaRestauracji");
        }
    }
}
