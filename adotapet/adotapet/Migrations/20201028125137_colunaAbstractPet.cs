using Microsoft.EntityFrameworkCore.Migrations;

namespace adotapet.Migrations
{
    public partial class colunaAbstractPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Pet",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Pet");
        }
    }
}
