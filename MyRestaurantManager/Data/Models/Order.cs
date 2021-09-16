namespace MyRestaurantManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class Order : BaseModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DishesOrdered = new HashSet<Dish>();
            this.DrinksOrdered = new HashSet<Drink>();
        }

        public int OrderNumber { get; set; }

        public string TableId { get; set; }

        public Table Table { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Dish> DishesOrdered { get; set; }

        public ICollection<Drink> DrinksOrdered { get; set; }

        public DateTime OrderClosed { get; set; }
    }
}
