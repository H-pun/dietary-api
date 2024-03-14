using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    public partial class foodDiaryDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "calories",
                table: "food_diary",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "feedback",
                table: "food_diary",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ma_daily_calorie",
                table: "food_diary",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "food_diary",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calories",
                table: "food_diary");

            migrationBuilder.DropColumn(
                name: "feedback",
                table: "food_diary");

            migrationBuilder.DropColumn(
                name: "ma_daily_calorie",
                table: "food_diary");

            migrationBuilder.DropColumn(
                name: "status",
                table: "food_diary");
        }
    }
}
