﻿// <auto-generated />
using System;
using MealPlannerAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MealPlannerAPI.Migrations
{
    [DbContext(typeof(MealPlannerDbContext))]
    [Migration("20240121120420_ReInitialMigration")]
    partial class ReInitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealPlannerAPI.Model.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MealId"));

                    b.Property<DateTime?>("MealDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MealId");

                    b.HasIndex(new[] { "MealDate" }, "MealDate");

                    b.HasIndex(new[] { "MealId" }, "MealId");

                    b.HasIndex(new[] { "MealName" }, "MealName");

                    b.ToTable("Meal", (string)null);
                });

            modelBuilder.Entity("MealPlannerAPI.Model.MealDetail", b =>
                {
                    b.Property<int>("MealDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MealDetailId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("MealDetailId");

                    b.HasIndex("MealId");

                    b.HasIndex("ProductId");

                    b.ToTable("MealDetails", (string)null);
                });

            modelBuilder.Entity("MealPlannerAPI.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal?>("Carbohydrates")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("Energy")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("Fat")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Protein")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("MealPlannerAPI.Model.UserPreference", b =>
                {
                    b.Property<int>("UserPreferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserPreferenceId"));

                    b.Property<int?>("DailyCarbsGoal")
                        .HasColumnType("int");

                    b.Property<int?>("DailyEnrgGoalHigh")
                        .HasColumnType("int");

                    b.Property<int?>("DailyEnrgGoalLow")
                        .HasColumnType("int");

                    b.Property<int?>("DailyFatGoal")
                        .HasColumnType("int");

                    b.Property<int?>("DailyProteinsGoal")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserPreferenceId");

                    b.ToTable("UserPreferences", (string)null);
                });

            modelBuilder.Entity("MealPlannerAPI.Model.MealDetail", b =>
                {
                    b.HasOne("MealPlannerAPI.Model.Meal", "Meal")
                        .WithMany("MealDetails")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MealPlannerAPI.Model.Product", "Product")
                        .WithMany("MealDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MealPlannerAPI.Model.Meal", b =>
                {
                    b.Navigation("MealDetails");
                });

            modelBuilder.Entity("MealPlannerAPI.Model.Product", b =>
                {
                    b.Navigation("MealDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
