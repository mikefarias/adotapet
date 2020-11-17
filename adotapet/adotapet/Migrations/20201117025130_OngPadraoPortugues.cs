using Microsoft.EntityFrameworkCore.Migrations;

namespace adotapet.Migrations
{
    public partial class OngPadraoPortugues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ong");

            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Ong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Ong",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Ong",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Ong");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Ong");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Ong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Ong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ong",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
