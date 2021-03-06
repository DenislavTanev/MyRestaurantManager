namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IDishTypesService
    {
        Task CreateAsync(string name);

        Task DeleteAsync(string id);

        DishTypeServiceModel GetById(string id);

        IEnumerable<DishTypeServiceModel> GetAll();
    }
}
