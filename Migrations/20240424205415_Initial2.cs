using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admini_Utilizatori_UtilizatorId",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizatori_Admini_AdminId",
                table: "Utilizatori");

            migrationBuilder.DropIndex(
                name: "IX_Admini_UtilizatorId",
                table: "Admini");

            migrationBuilder.AddColumn<int>(
                name: "UtilizatorId",
                table: "Utilizatori",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse",
                column: "ComandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizatori_Admini_AdminId",
                table: "Utilizatori",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilizatori_Admini_AdminId",
                table: "Utilizatori");

            migrationBuilder.DropIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Produse");

            migrationBuilder.CreateIndex(
                name: "IX_Admini_UtilizatorId",
                table: "Admini",
                column: "UtilizatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_Utilizatori_UtilizatorId",
                table: "Admini",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizatori_Admini_AdminId",
                table: "Utilizatori",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
