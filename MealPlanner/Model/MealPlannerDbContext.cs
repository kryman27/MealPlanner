using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerAPI.Model;

public partial class MealPlannerDbContext : DbContext
{
    public MealPlannerDbContext()
    {
    }

    public MealPlannerDbContext(DbContextOptions<MealPlannerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DailyMeal> DailyMeals { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<UserPreference> UserPreferences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MealPlannerDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.IdBrand).HasName("PK__Brands__3214EC0748D6769B");

            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Categori__3214EC07AE2EBB3E");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<DailyMeal>(entity =>
        {
            entity.HasKey(e => e.IdDailyMeal).HasName("PK__DailyMea__ABDB83F50E8749D1");

            entity.Property(e => e.IdDailyMeal).HasColumnName("id_daily_meal");
            entity.Property(e => e.DailyMealDate)
                .HasColumnType("date")
                .HasColumnName("daily_meal_date");
            entity.Property(e => e.MealId).HasColumnName("meal_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Meal).WithMany(p => p.DailyMeals)
                .HasForeignKey(d => d.MealId)
                .HasConstraintName("FK__DailyMeal__meal___06CD04F7");

            entity.HasOne(d => d.Product).WithMany(p => p.DailyMeals)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__DailyMeal__produ__07C12930");
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.IdMeal).HasName("PK__Meal__68A38B283CF9DB43");

            entity.ToTable("Meal");

            entity.Property(e => e.IdMeal).HasColumnName("id_meal");
            entity.Property(e => e.MealDate)
                .HasColumnType("date")
                .HasColumnName("meal_date");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Products__3214EC07002B2228");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");
            entity.Property(e => e.Energy).HasColumnName("energy");
            entity.Property(e => e.Fat).HasColumnName("fat");
            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.ProductName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Protein).HasColumnName("protein");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdBrand)
                .HasConstraintName("FK__Products__Brand__29572725");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Products__Catego__34C8D9D1");
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.HasKey(e => e.IdUserpreference).HasName("PK__UserPref__03C951EAE62173E9");

            entity.Property(e => e.IdUserpreference).HasColumnName("id_userpreference");
            entity.Property(e => e.DailyCarbsGoal).HasColumnName("daily_carbs_goal");
            entity.Property(e => e.DailyEnrgGoalHigh).HasColumnName("daily_enrg_goal_high");
            entity.Property(e => e.DailyEnrgGoalLow).HasColumnName("daily_enrg_goal_low");
            entity.Property(e => e.DailyFatGoal).HasColumnName("daily_fat_goal");
            entity.Property(e => e.DailyProteinsGoal).HasColumnName("daily_proteins_goal");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
