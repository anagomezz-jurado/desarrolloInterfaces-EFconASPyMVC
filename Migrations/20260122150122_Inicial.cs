using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFconASPyMVC.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hermandad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFundacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hermandad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePuesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hermano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HermandadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hermano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hermano_Hermandad_HermandadId",
                        column: x => x.HermandadId,
                        principalTable: "Hermandad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuestoHermano",
                columns: table => new
                {
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    HermanoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuestoHermano", x => new { x.PuestoId, x.HermanoId });
                    table.ForeignKey(
                        name: "FK_PuestoHermano_Hermano_HermanoId",
                        column: x => x.HermanoId,
                        principalTable: "Hermano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuestoHermano_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tunica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Talla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    HermanoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tunica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tunica_Hermano_HermanoId",
                        column: x => x.HermanoId,
                        principalTable: "Hermano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hermano_HermandadId",
                table: "Hermano",
                column: "HermandadId");

            migrationBuilder.CreateIndex(
                name: "IX_PuestoHermano_HermanoId",
                table: "PuestoHermano",
                column: "HermanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tunica_HermanoId",
                table: "Tunica",
                column: "HermanoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuestoHermano");

            migrationBuilder.DropTable(
                name: "Tunica");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "Hermano");

            migrationBuilder.DropTable(
                name: "Hermandad");
        }
    }
}
