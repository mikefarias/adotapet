using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace adotapet.Migrations
{
    public partial class novoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adotante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Profissao = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adotante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ong",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cnpj = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abstract = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Breed = table.Column<string>(nullable: true),
                    IdOng = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    IsAdopted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Ong_IdOng",
                        column: x => x.IdOng,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrevista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPet = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: true),
                    IdAdotante = table.Column<int>(nullable: false),
                    AdotanteId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrevista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrevista_Adotante_AdotanteId",
                        column: x => x.AdotanteId,
                        principalTable: "Adotante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entrevista_Pet_PetId",
                        column: x => x.PetId,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_AdotanteId",
                table: "Entrevista",
                column: "AdotanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_PetId",
                table: "Entrevista",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdOng",
                table: "Pet",
                column: "IdOng");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrevista");

            migrationBuilder.DropTable(
                name: "Adotante");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Ong");
        }
    }
}
