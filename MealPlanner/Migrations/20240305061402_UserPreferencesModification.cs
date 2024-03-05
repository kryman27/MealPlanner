using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserPreferencesModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyEnrgGoalHigh",
                table: "UserPreferences");

            migrationBuilder.RenameColumn(
                name: "DailyEnrgGoalLow",
                table: "UserPreferences",
                newName: "DailyEnrgGoal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DailyEnrgGoal",
                table: "UserPreferences",
                newName: "DailyEnrgGoalLow");

            migrationBuilder.AddColumn<int>(
                name: "DailyEnrgGoalHigh",
                table: "UserPreferences",
                type: "int",
                nullable: true);
        }
    }
}
