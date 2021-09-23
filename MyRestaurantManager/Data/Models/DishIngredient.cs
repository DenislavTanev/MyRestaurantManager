using MyRestaurantManager.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Data.Models
{
    public class DishIngredient : BaseDeletableModel<string>
    {
        public DishIngredient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string DishId { get; set; }

        public Dish Dish { get; set; }

        public string IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
