using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_UtilizatorId",
                table: "Comenzi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
