using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Admini_AdminId",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Utilizatori_UtilizatorId",
                table: "Produse");

            migrationBuilder.AddColumn<int>(
                name: "UtilizatorId",
                table: "Admini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Admini_AdminId",
                table: "Produse",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Utilizatori_UtilizatorId",
                table: "Produse",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Admini_AdminId",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Utilizatori_UtilizatorId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Admini");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Admini_AdminId",
                table: "Produse",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Utilizatori_UtilizatorId",
                table: "Produse",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
