using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class foodMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "max_daily_calorie",
                table: "food_diary",
                newName: "max_daily_calories");

            migrationBuilder.CreateTable(
                name: "food",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    unit = table.Column<string>(type: "text", nullable: true),
                    calories = table.Column<double>(type: "double precision", nullable: false),
                    fat = table.Column<double>(type: "double precision", nullable: false),
                    protein = table.Column<double>(type: "double precision", nullable: false),
                    carbohydrate = table.Column<double>(type: "double precision", nullable: false),
                    sugar = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food");

            migrationBuilder.RenameColumn(
                name: "max_daily_calories",
                table: "food_diary",
                newName: "max_daily_calorie");
        }
    }
}
