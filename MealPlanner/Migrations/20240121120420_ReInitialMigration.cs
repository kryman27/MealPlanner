using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MealName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrates = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    UserPreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyEnrgGoalLow = table.Column<int>(type: "int", nullable: true),
                    DailyEnrgGoalHigh = table.Column<int>(type: "int", nullable: true),
                    DailyFatGoal = table.Column<int>(type: "int", nullable: true),
                    DailyCarbsGoal = table.Column<int>(type: "int", nullable: true),
                    DailyProteinsGoal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.UserPreferenceId);
                });

            migrationBuilder.CreateTable(
                name: "MealDetails",
                columns: table => new
                {
                    MealDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDetails", x => x.MealDetailId);
                    table.ForeignKey(
                        name: "FK_MealDetails_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "MealDate",
                table: "Meal",
                column: "MealDate");

            migrationBuilder.CreateIndex(
                name: "MealId",
                table: "Meal",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "MealName",
                table: "Meal",
                column: "MealName");

            migrationBuilder.CreateIndex(
                name: "IX_MealDetails_MealId",
                table: "MealDetails",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealDetails_ProductId",
                table: "MealDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealDetails");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
