namespace MyRestaurantManager.Services.Services
{
    using System.Linq;

    using MyRestaurantManager.Data;
    using MyRestaurantManager.Services.Interfaces;
    using MyRestaurantManager.Services.Models;

    public class UsersService : IUsersService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public UsersService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public UserServiceModel GetById(string id)
        {
            var user = _context.Users
                .Where(x => x.Id == id)
                .Select(u => new UserServiceModel
                {
                    Id = u.Id,
                    RestaurantId = u.RestaurantId,
                    FullName = u.FullName,
                    StaffId = u.StaffId,
                }).FirstOrDefault();

            return user;
        }
    }
}
