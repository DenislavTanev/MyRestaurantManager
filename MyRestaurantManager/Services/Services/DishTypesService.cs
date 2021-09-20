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

    public class DishTypesService : IDishTypesService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public DishTypesService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name)
        {
            var dishType = new DishType
            {
                Name = name,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
            };

            await _context.AddAsync(dishType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var dishType = await _context.DishTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (dishType != null)
            {
                dishType.IsDeleted = true;
                dishType.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public IEnumerable<DishTypeServiceModel> GetAll()
        {
            var dishTypes = _context.DishTypes
                .Where(x => x.IsDeleted != true)
                .Select(x => new DishTypeServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return dishTypes;
        }

        public DishTypeServiceModel GetById(string id)
        {
            var dishType = _context.DishTypes
                .Where(x => x.Id == id)
                .Select(x => new DishTypeServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();

            return dishType;
        }
    }
}
