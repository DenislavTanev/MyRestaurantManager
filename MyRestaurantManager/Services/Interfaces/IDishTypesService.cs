namespace MyRestaurantManager.Services.Interfaces
{
    using MyRestaurantManager.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDishTypesService
    {
        Task CreateAsync(string name);

        Task DeleteAsync(string id);

        DishTypeServiceModel GetById(string id);

        IEnumerable<DishTypeServiceModel> GetAll();
    }
}
