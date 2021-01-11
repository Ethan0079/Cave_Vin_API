using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsic.Cave.A.Vin.Ethan.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaveId",
                table: "Bottles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Degree = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cave", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_CaveId",
                table: "Bottles",
                column: "CaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Cave_CaveId",
                table: "Bottles",
                column: "CaveId",
                principalTable: "Cave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Cave_CaveId",
                table: "Bottles");

            migrationBuilder.DropTable(
                name: "Cave");

            migrationBuilder.DropIndex(
                name: "IX_Bottles_CaveId",
                table: "Bottles");

            migrationBuilder.DropColumn(
                name: "CaveId",
                table: "Bottles");
        }
    }
}
