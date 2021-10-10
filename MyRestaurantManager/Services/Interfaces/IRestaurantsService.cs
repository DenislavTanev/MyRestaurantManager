using MyRestaurantManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Services.Interfaces
{
    public interface IRestaurantsService
    {
        Task CreateAsync(RestaurantServiceModel input);

        Task EditAsync(RestaurantServiceModel input);

        Task DeleteAsync(string id);

        RestaurantServiceModel GetById(string id);

    }
}
