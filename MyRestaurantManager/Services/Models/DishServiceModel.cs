namespace MyRestaurantManager.Services.Models
{
    using System.Collections.Generic;

    public class DishServiceModel
    {
        public string Name { get; set; }

        public string PortionQuantity { get; set; }

        public decimal Price { get; set; }

        public DishTypeServiceModel Type { get; set; }

        public ICollection<IngredientServiceModel> Ingredients { get; set; }

        public ImageServiceModel Image { get; set; }
    }
}
