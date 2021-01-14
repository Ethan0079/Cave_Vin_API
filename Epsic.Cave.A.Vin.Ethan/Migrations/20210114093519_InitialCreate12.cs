using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsic_Cave_A_Vin_Ethan.Migrations
{
    public partial class InitialCreate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles");

            migrationBuilder.AlterColumn<int>(
                name: "CaveId",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles",
                column: "CaveId",
                principalTable: "Caves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles");

            migrationBuilder.AlterColumn<int>(
                name: "CaveId",
                table: "Bottles",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles",
                column: "CaveId",
                principalTable: "Caves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
