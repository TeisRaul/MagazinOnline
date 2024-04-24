﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId1",
                table: "Comenzi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AdminId1",
                table: "Comenzi",
                column: "AdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Admini_AdminId1",
                table: "Comenzi",
                column: "AdminId1",
                principalTable: "Admini",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
