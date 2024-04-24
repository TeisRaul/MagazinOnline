using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi");

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
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id");
        }
    }
}
