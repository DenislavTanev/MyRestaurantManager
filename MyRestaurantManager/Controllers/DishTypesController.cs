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
    }
}
