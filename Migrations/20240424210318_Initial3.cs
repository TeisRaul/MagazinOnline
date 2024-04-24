using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admini_Comenzi_ComandaId",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Admini_Produse_ProdusId",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.DropIndex(
                name: "IX_Admini_ComandaId",
                table: "Admini");

            migrationBuilder.DropIndex(
                name: "IX_Admini_ProdusId",
                table: "Admini");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Admini");

            migrationBuilder.DropColumn(
                name: "ProdusId",
                table: "Admini");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Admini");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.AddColumn<int>(
                name: "UtilizatorId",
                table: "Utilizatori",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "Admini",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdusId",
                table: "Admini",
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
                name: "IX_Admini_ComandaId",
                table: "Admini",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Admini_ProdusId",
                table: "Admini",
                column: "ProdusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_Comenzi_ComandaId",
                table: "Admini",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_Produse_ProdusId",
                table: "Admini",
                column: "ProdusId",
                principalTable: "Produse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
