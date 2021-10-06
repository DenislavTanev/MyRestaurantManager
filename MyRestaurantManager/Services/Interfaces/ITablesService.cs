namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface ITablesService
    {
        Task CreateAsync(int number, string restaurantId);

        Task DeleteAsync(string id);

        TableServiceModel GetById(string id);

        IEnumerable<TableServiceModel> GetByRestaurant();
    }
}
