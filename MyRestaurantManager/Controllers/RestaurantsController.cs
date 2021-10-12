using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRestaurantManager.Infrastructures.Extensions;
using MyRestaurantManager.Services.Interfaces;
using MyRestaurantManager.ViewModels.Restaurants;

using System.Threading.Tasks;

namespace MyRestaurantManager.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantsService restaurantsService;

        public RestaurantsController(IRestaurantsService restaurantsService)
        {
            this.restaurantsService = restaurantsService;
        }

        public IActionResult Index(string restaurantId)
        {
            var restaurant = this.restaurantsService.GetById(restaurantId);

            var viewData = new RestaurantViewModel
            {
                RestaurantId = restaurant.Id,
                Name = restaurant.Name,
                Stars = restaurant.Stars,
                OwnerId = restaurant.OwnerId,
            };


            return View(viewData);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RestaurantCreateInputModel input)
        {
            var userId = this.User.Id();

            var restaurantId = await this.restaurantsService.CreateAsync(
                input.Name,
                input.Stars,
                userId);

            return this.RedirectToAction("Index", "Restaurant", new { restaurantId = restaurantId });
        }
    }
}
