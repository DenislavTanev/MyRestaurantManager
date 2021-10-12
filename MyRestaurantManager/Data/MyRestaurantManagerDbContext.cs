namespace MyRestaurantManager.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using MyRestaurantManager.Data.Models;

    public class MyRestaurantManagerDbContext : IdentityDbContext<User>
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

        public DbSet<RestaurantStaff> Staffs { get; set; }

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

            builder
                .Entity<Restaurant>()
                .HasOne(x => x.Owner)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<User>(x => x.RestaurantId);

            builder
                .Entity<Restaurant>()
                .HasOne(x => x.Staff)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<RestaurantStaff>(x => x.RestaurantId);
            

            base.OnModelCreating(builder);
        }
    }
}
