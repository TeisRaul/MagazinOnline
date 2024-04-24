using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Online.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    UtilizatorId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admini", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilizatori_Admini_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_comanda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nr_buc = table.Column<int>(type: "int", nullable: false),
                    DataComanda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StareComanda = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    UtilizatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comenzi_Admini_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comenzi_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categorie = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<float>(type: "real", nullable: false),
                    NumarBucati = table.Column<int>(type: "int", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orase = table.Column<int>(type: "int", nullable: false),
                    UtilizatorId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produse_Admini_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produse_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdusComanda",
                columns: table => new
                {
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusComanda", x => new { x.ProdusId, x.ComandaId });
                    table.ForeignKey(
                        name: "FK_ProdusComanda_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdusComanda_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admini_ComandaId",
                table: "Admini",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Admini_ProdusId",
                table: "Admini",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Admini_UtilizatorId",
                table: "Admini",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AdminId",
                table: "Comenzi",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusComanda_ComandaId",
                table: "ProdusComanda",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_AdminId",
                table: "Produse",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_UtilizatorId",
                table: "Produse",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizatori_AdminId",
                table: "Utilizatori",
                column: "AdminId");

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
                name: "FK_Admini_Utilizatori_UtilizatorId",
                table: "Admini",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admini_Comenzi_ComandaId",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Admini_Produse_ProdusId",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Admini_Utilizatori_UtilizatorId",
                table: "Admini");

            migrationBuilder.DropTable(
                name: "ProdusComanda");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Utilizatori");

            migrationBuilder.DropTable(
                name: "Admini");
        }
    }
}
