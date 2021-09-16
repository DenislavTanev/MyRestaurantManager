namespace MyRestaurantManager.Services.Interfaces
{
    using MyRestaurantManager.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDishesService
    {
        Task Create(DishServiceModel input);

        Task Edit(DishDetailsServiceModel input);

        Task Delete(string id);

        Task<DishDetailsServiceModel> GetByIdAsync(string id);

        IEnumerable<DishDetailsServiceModel> GetByRestaurantAsync(string id);

        IEnumerable<DishDetailsServiceModel> GetByDishTypeAsync(string restaurantId, string dishTypeId);

        Task SetAvailability(string id, bool availability);
    }
}
