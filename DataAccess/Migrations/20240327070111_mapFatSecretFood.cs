using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mapFatSecretFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calories",
                table: "food");

            migrationBuilder.DropColumn(
                name: "carbohydrate",
                table: "food");

            migrationBuilder.DropColumn(
                name: "fat",
                table: "food");

            migrationBuilder.DropColumn(
                name: "protein",
                table: "food");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "food");

            migrationBuilder.DropColumn(
                name: "url",
                table: "food");

            migrationBuilder.DropColumn(
                name: "web_name",
                table: "food");

            migrationBuilder.AddColumn<Guid>(
                name: "id_fat_secret",
                table: "food",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_food_id_fat_secret",
                table: "food",
                column: "id_fat_secret",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_food_fat_secret_food_id_fat_secret",
                table: "food",
                column: "id_fat_secret",
                principalTable: "fat_secret_food",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_food_fat_secret_food_id_fat_secret",
                table: "food");

            migrationBuilder.DropIndex(
                name: "ix_food_id_fat_secret",
                table: "food");

            migrationBuilder.DropColumn(
                name: "id_fat_secret",
                table: "food");

            migrationBuilder.AddColumn<float>(
                name: "calories",
                table: "food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "carbohydrate",
                table: "food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "fat",
                table: "food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "protein",
                table: "food",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "unit",
                table: "food",
                type: "text",
                nullable: true);

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
    }
}
