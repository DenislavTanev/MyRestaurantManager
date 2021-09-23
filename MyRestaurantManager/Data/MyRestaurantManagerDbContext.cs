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

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<DishType> DishTypes { get; set; }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<DrinkType> DrinkTypes { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuSection> MenuSections { get; set; }

        public DbSet<DishIngredient> DishesIngredients { get; set; }

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
