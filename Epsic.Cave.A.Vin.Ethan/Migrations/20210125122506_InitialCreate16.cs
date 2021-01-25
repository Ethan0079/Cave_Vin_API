using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsic_Cave_A_Vin_Ethan.Migrations
{
    public partial class InitialCreate16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Caves",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Caves");
        }
    }
}
