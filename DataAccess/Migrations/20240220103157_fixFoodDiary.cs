using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    public partial class fixFoodDiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary");

            migrationBuilder.CreateIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary");

            migrationBuilder.CreateIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary",
                column: "id_user",
                unique: true);
        }
    }
}
