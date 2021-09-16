namespace MyRestaurantManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class Ingredient : BaseDeletableModel<string>
    {
        public Ingredient()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Dishes = new HashSet<Dish>();
        }

        public string Name { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
