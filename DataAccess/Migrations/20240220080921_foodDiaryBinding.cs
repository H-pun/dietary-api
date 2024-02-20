using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    public partial class foodDiaryBinding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "id_user",
                table: "food_diary",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary",
                column: "id_user",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_food_diary_user_id_user",
                table: "food_diary",
                column: "id_user",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_food_diary_user_id_user",
                table: "food_diary");

            migrationBuilder.DropIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "food_diary");
        }
    }
}
