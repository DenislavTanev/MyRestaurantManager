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
    public class RestaurantsService : IRestaurantsService
    {
        private readonly MyRestaurantManagerDbContext _context;
        private readonly IUsersService usersService;

        public RestaurantsService(MyRestaurantManagerDbContext context, IUsersService usersService)
        {
            _context = context;
            this.usersService = usersService;
        }

        public async Task<string> CreateAsync(string name, int stars, string userId)
        {
            var user = usersService.GetById(userId);

            if (user.RestaurantId == null)
            {
                var restaurant = new Restaurant
                {
                    Name = name,
                    Stars = stars,
                    OwnerId = userId,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();

                return restaurant.Id;
            }
            else
            {
                //alert
                return "Error";
            }
        }

        public async Task DeleteAsync(string restaurantId, string userId)
        {
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(x => x.Id == restaurantId);

            if (restaurant.OwnerId == userId)
            {
                restaurant.IsDeleted = true;
                restaurant.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(RestaurantServiceModel input)
        {
            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (restaurant != null && restaurant.IsDeleted != true)
            {
                restaurant.Name = input.Name;
                restaurant.Stars = input.Stars;
            }

            await _context.SaveChangesAsync();
        }

        public RestaurantServiceModel GetById(string restaurantId)
        {
            var restaurant = _context.Restaurants
                .Where(x => x.Id == restaurantId)
                .Select(r => new RestaurantServiceModel
                {
                    Name = r.Name,
                    Stars = r.Stars,
                    OwnerId = r.OwnerId,
                })
                .FirstOrDefault();

            return restaurant;
        }
    }
}
