using MyRestaurantManager.Services.Interfaces;
using MyRestaurantManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Services.Services
{
    public class TablesService : ITablesService
    {
        public Task CreateAsync(int number, string restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public TableServiceModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableServiceModel> GetByRestaurant()
        {
            throw new NotImplementedException();
        }
    }
}
