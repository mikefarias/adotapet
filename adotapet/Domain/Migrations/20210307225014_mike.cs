using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ong_IdentityUser_UserId",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Ong");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ong",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Ong_UserId",
                table: "Ong",
                newName: "IX_Ong_IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Ong_IdentityUser_IdUsuario",
                table: "Ong",
                column: "IdUsuario",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ong_IdentityUser_IdUsuario",
                table: "Ong");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Ong",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ong_IdUsuario",
                table: "Ong",
                newName: "IX_Ong_UserId");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Ong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ong_IdentityUser_UserId",
                table: "Ong",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
