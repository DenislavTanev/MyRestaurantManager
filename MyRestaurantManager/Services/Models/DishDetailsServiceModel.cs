using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Services.Models
{
    public class DishDetailsServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PortionQuantity { get; set; }

        public decimal Price { get; set; }

        public DishTypeServiceModel Type { get; set; }

        public ICollection<IngredientServiceModel> Ingredients { get; set; }

        public ImageServiceModel Image { get; set; }
    }
}
