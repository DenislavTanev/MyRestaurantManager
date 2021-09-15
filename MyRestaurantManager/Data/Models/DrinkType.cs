namespace MyRestaurantManager.Data.Models
{
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class DrinkType : BaseModel<int>
    {
        public string Name { get; set; }

        public IEnumerable<Drink> Drinks { get; init; } = new List<Drink>();
    }
}
