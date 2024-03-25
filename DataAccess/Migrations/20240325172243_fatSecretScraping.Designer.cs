﻿// <auto-generated />
using System;
using Dietary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dietary.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240325172243_fatSecretScraping")]
    partial class fatSecretScraping
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dietary.DataAccess.Entities.FatSecretFood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BrandName")
                        .HasColumnType("text")
                        .HasColumnName("brand_name");

                    b.Property<long>("FoodId")
                        .HasColumnType("bigint")
                        .HasColumnName("food_id");

                    b.Property<string>("FoodName")
                        .HasColumnType("text")
                        .HasColumnName("food_name");

                    b.Property<string>("FoodType")
                        .HasColumnType("text")
                        .HasColumnName("food_type");

                    b.Property<string>("FoodUrl")
                        .HasColumnType("text")
                        .HasColumnName("food_url");

                    b.HasKey("Id")
                        .HasName("pk_fat_secret_food");

                    b.ToTable("fat_secret_food", (string)null);
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.FatSecretServing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<float>("AddedSugars")
                        .HasColumnType("real")
                        .HasColumnName("added_sugars");

                    b.Property<float>("Calcium")
                        .HasColumnType("real")
                        .HasColumnName("calcium");

                    b.Property<float>("Calories")
                        .HasColumnType("real")
                        .HasColumnName("calories");

                    b.Property<float>("Carbohydrate")
                        .HasColumnType("real")
                        .HasColumnName("carbohydrate");

                    b.Property<float>("Cholesterol")
                        .HasColumnType("real")
                        .HasColumnName("cholesterol");

                    b.Property<float>("Fat")
                        .HasColumnType("real")
                        .HasColumnName("fat");

                    b.Property<float>("Fiber")
                        .HasColumnType("real")
                        .HasColumnName("fiber");

                    b.Property<Guid>("IdFatSecretFood")
                        .HasColumnType("uuid")
                        .HasColumnName("id_fat_secret_food");

                    b.Property<float>("Iron")
                        .HasColumnType("real")
                        .HasColumnName("iron");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean")
                        .HasColumnName("is_default");

                    b.Property<string>("MeasurementDescription")
                        .HasColumnType("text")
                        .HasColumnName("measurement_description");

                    b.Property<float>("MetricServingAmount")
                        .HasColumnType("real")
                        .HasColumnName("metric_serving_amount");

                    b.Property<string>("MetricServingUnit")
                        .HasColumnType("text")
                        .HasColumnName("metric_serving_unit");

                    b.Property<float>("MonounsaturatedFat")
                        .HasColumnType("real")
                        .HasColumnName("monounsaturated_fat");

                    b.Property<float>("NumberOfUnits")
                        .HasColumnType("real")
                        .HasColumnName("number_of_units");

                    b.Property<float>("PolyunsaturatedFat")
                        .HasColumnType("real")
                        .HasColumnName("polyunsaturated_fat");

                    b.Property<float>("Potassium")
                        .HasColumnType("real")
                        .HasColumnName("potassium");

                    b.Property<float>("Protein")
                        .HasColumnType("real")
                        .HasColumnName("protein");

                    b.Property<float>("SaturatedFat")
                        .HasColumnType("real")
                        .HasColumnName("saturated_fat");

                    b.Property<string>("ServingDescription")
                        .HasColumnType("text")
                        .HasColumnName("serving_description");

                    b.Property<long>("ServingId")
                        .HasColumnType("bigint")
                        .HasColumnName("serving_id");

                    b.Property<string>("ServingUrl")
                        .HasColumnType("text")
                        .HasColumnName("serving_url");

                    b.Property<float>("Sodium")
                        .HasColumnType("real")
                        .HasColumnName("sodium");

                    b.Property<float>("Sugar")
                        .HasColumnType("real")
                        .HasColumnName("sugar");

                    b.Property<float>("TransFat")
                        .HasColumnType("real")
                        .HasColumnName("trans_fat");

                    b.Property<float>("VitaminA")
                        .HasColumnType("real")
                        .HasColumnName("vitamin_a");

                    b.Property<float>("VitaminC")
                        .HasColumnType("real")
                        .HasColumnName("vitamin_c");

                    b.Property<float>("VitaminD")
                        .HasColumnType("real")
                        .HasColumnName("vitamin_d");

                    b.HasKey("Id")
                        .HasName("pk_fat_secret_serving");

                    b.HasIndex("IdFatSecretFood")
                        .HasDatabaseName("ix_fat_secret_serving_id_fat_secret_food");

                    b.ToTable("fat_secret_serving", (string)null);
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<float>("Calories")
                        .HasColumnType("real")
                        .HasColumnName("calories");

                    b.Property<float>("Carbohydrate")
                        .HasColumnType("real")
                        .HasColumnName("carbohydrate");

                    b.Property<float>("Fat")
                        .HasColumnType("real")
                        .HasColumnName("fat");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<float>("Protein")
                        .HasColumnType("real")
                        .HasColumnName("protein");

                    b.Property<string>("Unit")
                        .HasColumnType("text")
                        .HasColumnName("unit");

                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.Property<string>("WebName")
                        .HasColumnType("text")
                        .HasColumnName("web_name");

                    b.HasKey("Id")
                        .HasName("pk_food");

                    b.ToTable("food", (string)null);
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.FoodDiary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added_at");

                    b.Property<float>("Calories")
                        .HasColumnType("real")
                        .HasColumnName("calories");

                    b.Property<string>("Category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("Feedback")
                        .HasColumnType("text")
                        .HasColumnName("feedback");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<float>("MaxDailyCalories")
                        .HasColumnType("real")
                        .HasColumnName("max_daily_calories");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_food_diary");

                    b.HasIndex("IdUser")
                        .HasDatabaseName("ix_food_diary_id_user");

                    b.ToTable("food_diary", (string)null);
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AppToken")
                        .HasColumnType("text")
                        .HasColumnName("app_token");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.UserData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ActivityLevel")
                        .HasColumnType("text")
                        .HasColumnName("activity_level");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<string>("Goal")
                        .HasColumnType("text")
                        .HasColumnName("goal");

                    b.Property<float>("Height")
                        .HasColumnType("real")
                        .HasColumnName("height");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<float>("WaistCircumference")
                        .HasColumnType("real")
                        .HasColumnName("waist_circumference");

                    b.Property<float>("Weight")
                        .HasColumnType("real")
                        .HasColumnName("weight");

                    b.Property<float>("WeightTarget")
                        .HasColumnType("real")
                        .HasColumnName("weight_target");

                    b.HasKey("Id")
                        .HasName("pk_user_data");

                    b.HasIndex("IdUser")
                        .IsUnique()
                        .HasDatabaseName("ix_user_data_id_user");

                    b.ToTable("user_data", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text")
                        .HasColumnName("friendly_name");

                    b.Property<string>("Xml")
                        .HasColumnType("text")
                        .HasColumnName("xml");

                    b.HasKey("Id")
                        .HasName("pk_data_protection_keys");

                    b.ToTable("data_protection_keys", (string)null);
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.FatSecretServing", b =>
                {
                    b.HasOne("Dietary.DataAccess.Entities.FatSecretFood", "FatSecretFood")
                        .WithMany("Servings")
                        .HasForeignKey("IdFatSecretFood")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_fat_secret_serving_fat_secret_food_id_fat_secret_food");

                    b.Navigation("FatSecretFood");
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.FoodDiary", b =>
                {
                    b.HasOne("Dietary.DataAccess.Entities.User", "User")
                        .WithMany("FoodDiary")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_food_diary_user_id_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.UserData", b =>
                {
                    b.HasOne("Dietary.DataAccess.Entities.User", "User")
                        .WithOne("UserData")
                        .HasForeignKey("Dietary.DataAccess.Entities.UserData", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_data_user_id_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.FatSecretFood", b =>
                {
                    b.Navigation("Servings");
                });

            modelBuilder.Entity("Dietary.DataAccess.Entities.User", b =>
                {
                    b.Navigation("FoodDiary");

                    b.Navigation("UserData");
                });
#pragma warning restore 612, 618
        }
    }
}
