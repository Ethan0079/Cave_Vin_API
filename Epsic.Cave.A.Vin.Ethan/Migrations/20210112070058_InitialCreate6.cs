using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsic_Cave_A_Vin_Ethan.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles");

            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Users_OwnerId",
                table: "Bottles");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaveId",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerBottle",
                table: "Bottles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles",
                column: "CaveId",
                principalTable: "Caves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Users_OwnerId",
                table: "Bottles",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Caves_CaveId",
                table: "Bottles");

            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Users_OwnerId",
                table: "Bottles");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bottles");

            migrationBuilder.DropColumn(
                name: "PricePerBottle",
                table: "Bottles");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Bottles",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Users_OwnerId",
                table: "Bottles",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
