namespace MyRestaurantManager.Data.Models
{
    using System;

    using MyRestaurantManager.Data.Common;

    public class Drink : BaseDeletableModel<string>
    {
        public Drink()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        public string TypeId { get; set; }

        public DrinkType Type { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }
    }
}
