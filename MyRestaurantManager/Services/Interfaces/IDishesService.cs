namespace MyRestaurantManager.Services.Interfaces
{
    using MyRestaurantManager.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDishesService
    {
        Task Create(DishServiceModel input);

        Task Edit(string id, DishServiceModel input);

        Task Delete(string id);

        Task<T> GetByIdAsync<T>(string id);

        IEnumerable<T> GetByRestaurantAsync<T>(string id);

        IEnumerable<T> GetByDishTypeAsync<T>(string restaurantId, string dishTypeId);
    }
}
