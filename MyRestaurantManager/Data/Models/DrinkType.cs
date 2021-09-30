namespace MyRestaurantManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class DrinkType : BaseDeletableModel<string>
    {
        public DrinkType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Drinks = new HashSet<Drink>();
        }

        public string Name { get; set; }

        public ICollection<Drink> Drinks { get; set; }
    }
}
