namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IIngredientsService
    {
        Task CreateAsync(string name);

        Task DeleteAsync(string id);

        IngredientServiceModel GetById(string id);

        IEnumerable<IngredientServiceModel> GetAll();
    }
}
