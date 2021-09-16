namespace MyRestaurantManager.Data.Models
{
    using System;

    using MyRestaurantManager.Data.Common;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public byte[] Img { get; set; }

        public string DishId { get; set; }

        public Dish Dish { get; set; }

        public string DrinkId { get; set; }

        public Drink Drink { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
