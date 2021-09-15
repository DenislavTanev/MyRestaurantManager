namespace MyRestaurantManager.Data.Models
{
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class DishType : BaseModel<int>
    {
        public string Name { get; set; }

        public IEnumerable<Dish> Dishes { get; init; } = new List<Dish>();
    }
}
