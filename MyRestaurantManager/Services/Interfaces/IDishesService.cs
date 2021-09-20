namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IDishesService
    {
        Task CreateAsync(DishServiceModel input);

        Task EditAsync(DishDetailsServiceModel input);

        Task DeleteAsync(string id);

        DishDetailsServiceModel GetById(string id);

        IEnumerable<DishDetailsServiceModel> GetByRestaurant(string id);

        IEnumerable<DishDetailsServiceModel> GetByDishType(string restaurantId, string dishTypeId);

        Task SetAvailabilityAsync(string id, bool availability);
    }
}
