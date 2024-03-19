using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addWaistCircumferenceDairy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ma_daily_calorie",
                table: "food_diary",
                newName: "max_daily_calorie");

            migrationBuilder.AddColumn<float>(
                name: "waist_circumference",
                table: "user_data",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "waist_circumference",
                table: "user_data");

            migrationBuilder.RenameColumn(
                name: "max_daily_calorie",
                table: "food_diary",
                newName: "ma_daily_calorie");
        }
    }
}
