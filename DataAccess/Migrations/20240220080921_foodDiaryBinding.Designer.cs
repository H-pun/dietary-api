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
    [Migration("20240220080921_foodDiaryBinding")]
    partial class foodDiaryBinding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dietary.DataAccess.Entities.FoodDiary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added_at");

                    b.Property<string>("Category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<string>("FilePath")
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_food_diary");

                    b.HasIndex("IdUser")
                        .IsUnique()
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

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

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

            modelBuilder.Entity("Dietary.DataAccess.Entities.FoodDiary", b =>
                {
                    b.HasOne("Dietary.DataAccess.Entities.User", "User")
                        .WithOne("FoodDiary")
                        .HasForeignKey("Dietary.DataAccess.Entities.FoodDiary", "IdUser")
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

            modelBuilder.Entity("Dietary.DataAccess.Entities.User", b =>
                {
                    b.Navigation("FoodDiary");

                    b.Navigation("UserData");
                });
#pragma warning restore 612, 618
        }
    }
}
