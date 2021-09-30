namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IDrinksService
    {
        Task CreateAsync(DrinkCreateServiceModel input);

        Task EditAsync(DrinkDetailsServiceModel input);

        Task DeleteAsync(string id);

        DrinkDetailsServiceModel GetById(string id);

        IEnumerable<DrinkDetailsServiceModel> GetByRestaurant(string id);

        IEnumerable<DrinkDetailsServiceModel> GetByDrinkType(string restaurantId, string drinkTypeId);

        Task SetAvailabilityAsync(string id, bool availability);
    }
}
