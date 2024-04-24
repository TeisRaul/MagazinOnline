using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_AdminId",
                table: "Comenzi");

            migrationBuilder.DropIndex(
                name: "IX_Comenzi_AdminId",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Comenzi");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Admini_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Comenzi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AdminId",
                table: "Comenzi",
                column: "AdminId");

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
