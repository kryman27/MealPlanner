using Microsoft.EntityFrameworkCore;
using ModelsLib.Model;

namespace MealPlannerAPI.Database
{
    public partial class MealPlannerDbContext : DbContext
    {
        public MealPlannerDbContext()
        {

        }

        public MealPlannerDbContext(DbContextOptions<MealPlannerDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<MealDetail> MealProducts { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MealPlannerDB;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasKey(e => e.MealId);
                entity.ToTable("Meal");

                entity.HasIndex(e => e.MealId, "MealId");
                entity.HasIndex(e => e.MealDate, "MealDate");
                entity.HasIndex(e => e.MealName, "MealName");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.ToTable("Products");
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.Protein).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Carbohydrates).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Fat).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Energy).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ProductName).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<MealDetail>(entity =>
            {
                entity.HasKey(e => e.MealDetailId);
                entity.ToTable("MealDetails");

                // entity.HasOne(d => d.Product).WithMany(p => p.MealDetails).HasForeignKey(md => md.ProductId);
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.HasKey(e => e.UserPreferenceId);
                entity.ToTable("UserPreferences");
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("UserData");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
