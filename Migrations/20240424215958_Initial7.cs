using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi",
                column: "AdminId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
