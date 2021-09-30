using Microsoft.EntityFrameworkCore;
using MyRestaurantManager.Data;
using MyRestaurantManager.Data.Models;
using MyRestaurantManager.Services.Interfaces;
using MyRestaurantManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Services.Services
{
    public class DrinkTypesService : IDrinkTypesService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public DrinkTypesService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name)
        {
            var drinkType = new DrinkType
            {
                Name = name,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
            };

            await _context.AddAsync(drinkType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var drinkType = await _context.DrinkTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (drinkType != null)
            {
                drinkType.IsDeleted = true;
                drinkType.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public IEnumerable<DrinkTypeServiceModel> GetAll()
        {
            var drinkType = _context.DrinkTypes
               .Where(x => x.IsDeleted != true)
               .Select(x => new DrinkTypeServiceModel
               {
                   Id = x.Id,
                   Name = x.Name,
               })
               .ToList();

            return drinkType;
        }

        public DrinkTypeServiceModel GetById(string id)
        {
            var drinkType = _context.DrinkTypes
                .Where(x => x.Id == id)
                .Select(x => new DrinkTypeServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();

            return drinkType;
        }
    }
}
