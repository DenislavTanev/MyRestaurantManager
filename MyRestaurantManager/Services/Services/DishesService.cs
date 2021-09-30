namespace MyRestaurantManager.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using MyRestaurantManager.Data;
    using MyRestaurantManager.Data.Models;
    using MyRestaurantManager.Services.Interfaces;
    using MyRestaurantManager.Services.Models;

    public class DishesService : IDishesService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public DishesService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DishCreateServiceModel input)
        {
            var dish = new Dish
            {
                Name = input.Name,
                PortionQuantity = input.PortionQuantity,
                Price = input.Price,
                IsAvailable = true,
                TypeId = input.Type.Id,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _context.Dishes.AddAsync(dish);

            var img = new Image
            {
                Img = input.Image,
                DishId = dish.Id,
            };

            foreach (var ingredient in input.Ingredients)
            {
                var dishIngredient = new DishIngredient
                {
                    DishId = dish.Id,
                    IngredientId = ingredient.Id,
                };

                await _context.DishesIngredients.AddAsync(dishIngredient);
            }

            await _context.Images.AddAsync(img);

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
            var dishes = _context.Dishes
                 .Where(x => x.RestaurantId == restaurantId && x.TypeId == dishTypeId)
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
                         Id = i.IngredientId,
                         Name = i.Ingredient.Name,
                     }).ToList(),
                 })
                 .ToList();

            return dishes;
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
                        Id = i.IngredientId,
                        Name = i.Ingredient.Name,
                    }).ToList(),
                })
                .FirstOrDefault();

            return dish;
        }

        public IEnumerable<DishDetailsServiceModel> GetByIngredient(string restaurantId, string ingredientId)
        {
            var dishes = _context.Dishes
                 .Where(x => x.RestaurantId == restaurantId && x.Ingredients.Any(x => x.IngredientId == ingredientId))
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
                         Id = i.IngredientId,
                         Name = i.Ingredient.Name,
                     }).ToList(),
                 })
                 .ToList();

            return dishes;
        }

        public IEnumerable<DishDetailsServiceModel> GetByRestaurant(string restaurantId)
        {
             var dishes = _context.Dishes
                 .Where(x => x.RestaurantId == restaurantId)
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
                         Id = i.IngredientId,
                         Name = i.Ingredient.Name,
                     }).ToList(),
                 })
                 .ToList();

            return dishes;
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
