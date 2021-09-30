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

    public class IngredientsService : IIngredientsService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public IngredientsService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name)
        {
            var ingredient = new Ingredient
            {
                Name = name,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
            };

            await _context.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);

            if (ingredient != null)
            {
                ingredient.IsDeleted = true;
                ingredient.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public IEnumerable<IngredientServiceModel> GetAll()
        {
            var ingredient = _context.Ingredients
               .Where(x => x.IsDeleted != true)
               .Select(x => new IngredientServiceModel
               {
                   Id = x.Id,
                   Name = x.Name,
               })
               .ToList();

            return ingredient;
        }

        public IngredientServiceModel GetById(string id)
        {
            var ingredient = _context.Ingredients
               .Where(x => x.IsDeleted != true)
               .Select(x => new IngredientServiceModel
               {
                   Id = x.Id,
                   Name = x.Name,
               })
               .FirstOrDefault();

            return ingredient;
        }
    }
}
