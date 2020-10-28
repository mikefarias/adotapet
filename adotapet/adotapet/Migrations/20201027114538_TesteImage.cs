using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace adotapet.Migrations
{
    public partial class TesteImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImgProfile",
                table: "Pet",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TesteImagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesteImagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TesteImagem");

            migrationBuilder.DropColumn(
                name: "ImgProfile",
                table: "Pet");
        }
    }
}
