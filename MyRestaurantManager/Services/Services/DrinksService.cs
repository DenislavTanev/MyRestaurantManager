namespace MyRestaurantManager.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using MyRestaurantManager.Data;
    using MyRestaurantManager.Services.Interfaces;
    using MyRestaurantManager.Services.Models;

    public class DrinksService : IDrinksService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public DrinksService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DrinkCreateServiceModel input)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(string id)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(x => x.Id == id);

            if (drink != null)
            {
                drink.IsDeleted = true;
                drink.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(DrinkDetailsServiceModel input)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(x => x.Id == input.Id);

            drink.Name = input.Name;
            drink.Quantity = input.Quantity;
            drink.Price = input.Price;
            drink.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<DrinkDetailsServiceModel> GetByDrinkType(string restaurantId, string drinkTypeId)
        {
            var drinks = _context.Drinks
                .Where(x => x.RestaurantId == restaurantId && x.TypeId == drinkTypeId)
                .Select(x => new DrinkDetailsServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Type = new DrinkTypeServiceModel
                    {
                        Id = x.TypeId,
                        Name = x.Type.Name
                    },
                    Image = new ImageServiceModel
                    {
                        Id = x.ImageId,
                        Img = x.Image.Img,
                    },
                })
                .ToList();

            return drinks;
        }

        public DrinkDetailsServiceModel GetById(string id)
        {
            var drink = _context.Drinks
                .Where(x => x.Id == id)
                .Select(x => new DrinkDetailsServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Type = new DrinkTypeServiceModel
                    {
                        Id = x.TypeId,
                        Name = x.Type.Name
                    },
                    Image = new ImageServiceModel
                    {
                        Id = x.ImageId,
                        Img = x.Image.Img,
                    },
                })
                .FirstOrDefault();

            return drink;
        }

        public IEnumerable<DrinkDetailsServiceModel> GetByRestaurant(string id)
        {
            var drinks = _context.Drinks
                .Where(x => x.RestaurantId == id)
                .Select(x => new DrinkDetailsServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Type = new DrinkTypeServiceModel
                    {
                        Id = x.TypeId,
                        Name = x.Type.Name
                    },
                    Image = new ImageServiceModel
                    {
                        Id = x.ImageId,
                        Img = x.Image.Img,
                    },
                })
                .ToList();

            return drinks;
        }

        public async Task SetAvailabilityAsync(string id, bool availability)
        {
            var drink = await _context.Drinks.FirstOrDefaultAsync(x => x.Id == id);

            if (drink != null)
            {
                drink.IsAvailable = availability;
            }

            await _context.SaveChangesAsync();
        }
    }
}
