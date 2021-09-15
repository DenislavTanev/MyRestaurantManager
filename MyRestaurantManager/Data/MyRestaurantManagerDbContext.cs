namespace MyRestaurantManager.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MyRestaurantManager.Data.Models;

    public class MyRestaurantManagerDbContext : IdentityDbContext
    {
        public MyRestaurantManagerDbContext(DbContextOptions<MyRestaurantManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; init; }

        public DbSet<DishType> DishTypes { get; init; }

        public DbSet<Drink> Drinks { get; init; }

        public DbSet<DrinkType> DrinkTypes { get; init; }

        public DbSet<Image> Images { get; init; }

        public DbSet<Ingredient> Ingredients { get; init; }

        public DbSet<Order> Orders { get; init; }

        public DbSet<Table> Tables { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Dish>()
                .HasOne(x => x.Image)
                .WithOne(x => x.Dish)
                .HasForeignKey<Image>(x => x.DishId);

            builder
               .Entity<Drink>()
               .HasOne(x => x.Image)
               .WithOne(x => x.Drink)
               .HasForeignKey<Image>(x => x.DrinkId);

            base.OnModelCreating(builder);
        }
    }
}
