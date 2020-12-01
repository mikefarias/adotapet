using Microsoft.EntityFrameworkCore.Migrations;

namespace adotapet.Migrations
{
    public partial class ajustesModelEntrevista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrevista_Adotante_AdotanteId",
                table: "Entrevista");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrevista_Pet_PetId",
                table: "Entrevista");

            migrationBuilder.DropIndex(
                name: "IX_Entrevista_AdotanteId",
                table: "Entrevista");

            migrationBuilder.DropIndex(
                name: "IX_Entrevista_PetId",
                table: "Entrevista");

            migrationBuilder.DropColumn(
                name: "AdotanteId",
                table: "Entrevista");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Entrevista");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_IdAdotante",
                table: "Entrevista",
                column: "IdAdotante");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_IdPet",
                table: "Entrevista",
                column: "IdPet");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrevista_Adotante_IdAdotante",
                table: "Entrevista",
                column: "IdAdotante",
                principalTable: "Adotante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrevista_Pet_IdPet",
                table: "Entrevista",
                column: "IdPet",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrevista_Adotante_IdAdotante",
                table: "Entrevista");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrevista_Pet_IdPet",
                table: "Entrevista");

            migrationBuilder.DropIndex(
                name: "IX_Entrevista_IdAdotante",
                table: "Entrevista");

            migrationBuilder.DropIndex(
                name: "IX_Entrevista_IdPet",
                table: "Entrevista");

            migrationBuilder.AddColumn<int>(
                name: "AdotanteId",
                table: "Entrevista",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Entrevista",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_AdotanteId",
                table: "Entrevista",
                column: "AdotanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevista_PetId",
                table: "Entrevista",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrevista_Adotante_AdotanteId",
                table: "Entrevista",
                column: "AdotanteId",
                principalTable: "Adotante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrevista_Pet_PetId",
                table: "Entrevista",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
