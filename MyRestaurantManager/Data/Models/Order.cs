namespace MyRestaurantManager.Data.Models
{
    using MyRestaurantManager.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Order : BaseModel<int>
    {
        public int OrderNumber { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public IEnumerable<Dish> DishesOrdered { get; init; } = new List<Dish>();

        public IEnumerable<Drink> DrinksOrdered { get; init; } = new List<Drink>();

        public DateTime OrderClosed { get; set; }
    }
}
