namespace MyRestaurantManager.Data.Models
{
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class Dish : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string PortionQuantity { get; set; }

        public decimal Price { get; set; }

        public int TypeId { get; set; }

        public DishType Type { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; init; } = new List<Ingredient>();

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
