namespace MyRestaurantManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class Dish : BaseDeletableModel<string>
    {
        public Dish()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Ingredients = new HashSet<Ingredient>();
        }

        public string Name { get; set; }

        public string PortionQuantity { get; set; }

        public decimal Price { get; set; }

        public string TypeId { get; set; }

        public DishType Type { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }

        public bool IsAvailable { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
