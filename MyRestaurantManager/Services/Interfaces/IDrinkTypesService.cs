namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IDrinkTypesService
    {
        Task CreateAsync(string name);

        Task DeleteAsync(string id);

        DrinkTypeServiceModel GetById(string id);

        IEnumerable<DrinkTypeServiceModel> GetAll();
    }
}
