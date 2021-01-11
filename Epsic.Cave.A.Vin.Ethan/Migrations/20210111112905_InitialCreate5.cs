using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsic.Cave.A.Vin.Ethan.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Cave_CaveId",
                table: "Bottles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cave",
                table: "Cave");

            migrationBuilder.RenameTable(
                name: "Cave",
                newName: "Caves");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caves",
                table: "Caves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles",
                column: "CaveId",
                principalTable: "Caves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caves",
                table: "Caves");

            migrationBuilder.RenameTable(
                name: "Caves",
                newName: "Cave");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cave",
                table: "Cave",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Cave_CaveId",
                table: "Bottles",
                column: "CaveId",
                principalTable: "Cave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
