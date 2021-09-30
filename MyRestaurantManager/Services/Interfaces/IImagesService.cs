namespace MyRestaurantManager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyRestaurantManager.Services.Models;

    public interface IImagesService
    {
        Task CreateAsync(ImageCreateServiceModel input);

        Task EditAsync(ImageServiceModel input);

        Task DeleteAsync(string id);

        ImageServiceModel GetById(string id);

        IEnumerable<ImageServiceModel> GetByRestaurant(string restaurantId);
    }
}
