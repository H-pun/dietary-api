using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeSugar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sugar",
                table: "food");

            migrationBuilder.AlterColumn<float>(
                name: "max_daily_calories",
                table: "food_diary",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "calories",
                table: "food_diary",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "protein",
                table: "food",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "fat",
                table: "food",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "carbohydrate",
                table: "food",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "calories",
                table: "food",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "food",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "web_name",
                table: "food",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "food");

            migrationBuilder.DropColumn(
                name: "web_name",
                table: "food");

            migrationBuilder.AlterColumn<double>(
                name: "max_daily_calories",
                table: "food_diary",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "calories",
                table: "food_diary",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "protein",
                table: "food",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "fat",
                table: "food",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "carbohydrate",
                table: "food",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "calories",
                table: "food",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<double>(
                name: "sugar",
                table: "food",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
