using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fatSecretScraping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fat_secret_food",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    food_id = table.Column<long>(type: "bigint", nullable: false),
                    food_name = table.Column<string>(type: "text", nullable: true),
                    brand_name = table.Column<string>(type: "text", nullable: true),
                    food_type = table.Column<string>(type: "text", nullable: true),
                    food_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fat_secret_food", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fat_secret_serving",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_fat_secret_food = table.Column<Guid>(type: "uuid", nullable: false),
                    serving_id = table.Column<long>(type: "bigint", nullable: false),
                    serving_description = table.Column<string>(type: "text", nullable: true),
                    serving_url = table.Column<string>(type: "text", nullable: true),
                    number_of_units = table.Column<float>(type: "real", nullable: false),
                    measurement_description = table.Column<string>(type: "text", nullable: true),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    calories = table.Column<float>(type: "real", nullable: false),
                    carbohydrate = table.Column<float>(type: "real", nullable: false),
                    protein = table.Column<float>(type: "real", nullable: false),
                    fat = table.Column<float>(type: "real", nullable: false),
                    saturated_fat = table.Column<float>(type: "real", nullable: false),
                    trans_fat = table.Column<float>(type: "real", nullable: false),
                    cholesterol = table.Column<float>(type: "real", nullable: false),
                    sodium = table.Column<float>(type: "real", nullable: false),
                    potassium = table.Column<float>(type: "real", nullable: false),
                    fiber = table.Column<float>(type: "real", nullable: false),
                    sugar = table.Column<float>(type: "real", nullable: false),
                    added_sugars = table.Column<float>(type: "real", nullable: false),
                    calcium = table.Column<float>(type: "real", nullable: false),
                    iron = table.Column<float>(type: "real", nullable: false),
                    metric_serving_amount = table.Column<float>(type: "real", nullable: false),
                    metric_serving_unit = table.Column<string>(type: "text", nullable: true),
                    polyunsaturated_fat = table.Column<float>(type: "real", nullable: false),
                    monounsaturated_fat = table.Column<float>(type: "real", nullable: false),
                    vitamin_d = table.Column<float>(type: "real", nullable: false),
                    vitamin_a = table.Column<float>(type: "real", nullable: false),
                    vitamin_c = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fat_secret_serving", x => x.id);
                    table.ForeignKey(
                        name: "fk_fat_secret_serving_fat_secret_food_id_fat_secret_food",
                        column: x => x.id_fat_secret_food,
                        principalTable: "fat_secret_food",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_fat_secret_serving_id_fat_secret_food",
                table: "fat_secret_serving",
                column: "id_fat_secret_food");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fat_secret_serving");

            migrationBuilder.DropTable(
                name: "fat_secret_food");
        }
    }
}
