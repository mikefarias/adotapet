using Microsoft.EntityFrameworkCore.Migrations;

namespace adotapet.Migrations
{
    public partial class relationPetOng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Ong_OngId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_OngId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "OngId",
                table: "Pet");

            migrationBuilder.AddColumn<int>(
                name: "IdOng",
                table: "Pet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdOng",
                table: "Pet",
                column: "IdOng");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Ong_IdOng",
                table: "Pet",
                column: "IdOng",
                principalTable: "Ong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Ong_IdOng",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_IdOng",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "IdOng",
                table: "Pet");

            migrationBuilder.AddColumn<int>(
                name: "OngId",
                table: "Pet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OngId",
                table: "Pet",
                column: "OngId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Ong_OngId",
                table: "Pet",
                column: "OngId",
                principalTable: "Ong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
