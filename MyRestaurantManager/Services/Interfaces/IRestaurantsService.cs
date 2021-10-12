using MyRestaurantManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Services.Interfaces
{
    public interface IRestaurantsService
    {
        Task<string> CreateAsync(string name, int stars, string userId);

        Task EditAsync(RestaurantServiceModel input);

        Task DeleteAsync(string restaurantId, string userId);

        RestaurantServiceModel GetById(string restaurantId);

    }
}
