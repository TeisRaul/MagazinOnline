using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId1",
                table: "Comenzi");

            migrationBuilder.DropIndex(
                name: "IX_Comenzi_AdminId1",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "AdminId1",
                table: "Comenzi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId1",
                table: "Comenzi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AdminId1",
                table: "Comenzi",
                column: "AdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId1",
                table: "Comenzi",
                column: "AdminId1",
                principalTable: "Admini",
                principalColumn: "Id");
        }
    }
}
