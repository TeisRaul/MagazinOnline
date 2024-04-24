using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaProdus");

            migrationBuilder.RenameColumn(
                name: "Nr_comanda",
                table: "Comenzi",
                newName: "NrComanda");

            migrationBuilder.RenameColumn(
                name: "Nr_buc",
                table: "Comenzi",
                newName: "NrBuc");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NrComanda",
                table: "Comenzi",
                newName: "Nr_comanda");

            migrationBuilder.RenameColumn(
                name: "NrBuc",
                table: "Comenzi",
                newName: "Nr_buc");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Produse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ComandaProdus",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProdusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaProdus", x => new { x.ComandaId, x.ProdusId });
                    table.ForeignKey(
                        name: "FK_ComandaProdus_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaProdus_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProdus_ProdusId",
                table: "ComandaProdus",
                column: "ProdusId");
        }
    }
}
