using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "data_protection_keys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    friendly_name = table.Column<string>(type: "text", nullable: true),
                    xml = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_data_protection_keys", x => x.id);
                });

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
                name: "food",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    web_name = table.Column<string>(type: "text", nullable: true),
                    unit = table.Column<string>(type: "text", nullable: true),
                    calories = table.Column<float>(type: "real", nullable: false),
                    fat = table.Column<float>(type: "real", nullable: false),
                    protein = table.Column<float>(type: "real", nullable: false),
                    carbohydrate = table.Column<float>(type: "real", nullable: false),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    app_token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "food_diary",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_user = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<string>(type: "text", nullable: true),
                    added_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true),
                    calories = table.Column<float>(type: "real", nullable: false),
                    max_daily_calories = table.Column<float>(type: "real", nullable: false),
                    feedback = table.Column<string>(type: "text", nullable: true),
                    file_path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_diary", x => x.id);
                    table.ForeignKey(
                        name: "fk_food_diary_user_id_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_user = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    height = table.Column<float>(type: "real", nullable: false),
                    waist_circumference = table.Column<float>(type: "real", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: true),
                    goal = table.Column<string>(type: "text", nullable: true),
                    weight_target = table.Column<float>(type: "real", nullable: false),
                    activity_level = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_data", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_data_user_id_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_fat_secret_serving_id_fat_secret_food",
                table: "fat_secret_serving",
                column: "id_fat_secret_food");

            migrationBuilder.CreateIndex(
                name: "ix_food_diary_id_user",
                table: "food_diary",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "ix_user_data_id_user",
                table: "user_data",
                column: "id_user",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "data_protection_keys");

            migrationBuilder.DropTable(
                name: "fat_secret_serving");

            migrationBuilder.DropTable(
                name: "food");

            migrationBuilder.DropTable(
                name: "food_diary");

            migrationBuilder.DropTable(
                name: "user_data");

            migrationBuilder.DropTable(
                name: "fat_secret_food");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
