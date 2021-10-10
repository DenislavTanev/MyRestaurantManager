using Microsoft.AspNetCore.Mvc;
using MyRestaurantManager.Services.Interfaces;
using MyRestaurantManager.ViewModels.DishTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Controllers
{
    public class DishTypesController : Controller
    {
        private readonly IDishTypesService dishTypesService;

        public DishTypesController(IDishTypesService dishTypesService)
        {
            this.dishTypesService = dishTypesService;
        }

        public IActionResult Index()
        {
            var dishTypes = dishTypesService
                .GetAll()
                .Select(e => new DishTypesViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                })
                .ToList();

            return this.View(dishTypes);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DishTypeCreateInputModel input)
        {
            await dishTypesService.CreateAsync(input.Name);

            return this.RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var dishType = dishTypesService.GetById(id);

            if (dishType != null)
            {
                await dishTypesService.DeleteAsync(id);
            };

            return this.RedirectToAction("Index", "DishTypes");
        }
    }
}
