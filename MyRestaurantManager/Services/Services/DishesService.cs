namespace MyRestaurantManager.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using MyRestaurantManager.Data;
    using MyRestaurantManager.Data.Models;
    using MyRestaurantManager.Services.Interfaces;
    using MyRestaurantManager.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DishesService : IDishesService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public DishesService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DishServiceModel input)
        {
            var dish = new Dish
            {
                Name = input.Name,
                PortionQuantity = input.PortionQuantity,
                Price = input.Price,
                IsAvailable = false,
                TypeId = input.Type.Id,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _context.AddAsync(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);

            if (dish != null)
            {
                dish.IsDeleted = true;
                dish.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(DishDetailsServiceModel input)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == input.Id);

            dish.Name = input.Name;
            dish.PortionQuantity = input.PortionQuantity;
            dish.Price = input.Price;
            dish.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public IEnumerable<DishDetailsServiceModel> GetByDishType(string restaurantId, string dishTypeId)
        {
            throw new NotImplementedException();
        }

        public DishDetailsServiceModel GetById(string id)
        {
            var dish = _context.Dishes
                .Where(x => x.Id == id)
                .Select(x => new DishDetailsServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PortionQuantity = x.PortionQuantity,
                    Price = x.Price,
                    Type = new DishTypeServiceModel
                    {
                        Id = x.TypeId,
                        Name = x.Type.Name
                    },
                    Image = new ImageServiceModel
                    {
                        Id = x.ImageId,
                        Img = x.Image.Img,
                    },
                    Ingredients = x.Ingredients.Select(i => new IngredientServiceModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                    }).ToList(),
                })
                .FirstOrDefault();

            return dish;
        }

        public IEnumerable<DishDetailsServiceModel> GetByRestaurant(string id)
        {
            throw new NotImplementedException();
        }

        public async Task SetAvailabilityAsync(string id, bool availability)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);

            if (dish != null)
            {
                dish.IsAvailable = availability;
            }

            await _context.SaveChangesAsync();
        }
    }
}
