namespace MyRestaurantManager.Services.Interfaces
{
    using MyRestaurantManager.Services.Models;

    public interface IUsersService
    {
        UserServiceModel GetById(string id);
    }
}
