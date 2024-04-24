using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdusComanda_Comenzi_ComandaId",
                table: "ProdusComanda");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusComanda_Produse_ProdusId",
                table: "ProdusComanda");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusComanda_Comenzi_ComandaId",
                table: "ProdusComanda",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusComanda_Produse_ProdusId",
                table: "ProdusComanda",
                column: "ProdusId",
                principalTable: "Produse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdusComanda_Comenzi_ComandaId",
                table: "ProdusComanda");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdusComanda_Produse_ProdusId",
                table: "ProdusComanda");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusComanda_Comenzi_ComandaId",
                table: "ProdusComanda",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdusComanda_Produse_ProdusId",
                table: "ProdusComanda",
                column: "ProdusId",
                principalTable: "Produse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
