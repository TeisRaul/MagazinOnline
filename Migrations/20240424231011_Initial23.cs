using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse");

            migrationBuilder.DropIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Admini");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Produse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Comenzi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId1",
                table: "Comenzi",
                type: "int",
                nullable: true);

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
                name: "IX_Comenzi_AdminId",
                table: "Comenzi",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AdminId1",
                table: "Comenzi",
                column: "AdminId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProdus_ProdusId",
                table: "ComandaProdus",
                column: "ProdusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId1",
                table: "Comenzi",
                column: "AdminId1",
                principalTable: "Admini",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId1",
                table: "Comenzi");

            migrationBuilder.DropTable(
                name: "ComandaProdus");

            migrationBuilder.DropIndex(
                name: "IX_Comenzi_AdminId",
                table: "Comenzi");

            migrationBuilder.DropIndex(
                name: "IX_Comenzi_AdminId1",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "AdminId1",
                table: "Comenzi");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UtilizatorId",
                table: "Admini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse",
                column: "ComandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
