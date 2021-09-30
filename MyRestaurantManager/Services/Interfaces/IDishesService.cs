namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IDishesService
    {
        Task CreateAsync(DishCreateServiceModel input);

        Task EditAsync(DishDetailsServiceModel input);

        Task DeleteAsync(string id);

        DishDetailsServiceModel GetById(string id);

        IEnumerable<DishDetailsServiceModel> GetByRestaurant(string restaurantId);

        IEnumerable<DishDetailsServiceModel> GetByIngredient(string restaurantId, string ingredientId);

        IEnumerable<DishDetailsServiceModel> GetByDishType(string restaurantId, string dishTypeId);

        Task SetAvailabilityAsync(string id, bool availability);
    }
}
