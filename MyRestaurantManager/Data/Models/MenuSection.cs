namespace MyRestaurantManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class MenuSection : BaseDeletableModel<string>
    {
        public MenuSection()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Dishes = new HashSet<Dish>();
            this.Drinks = new HashSet<Drink>();
        }

        public string DishTypeId { get; set; }

        public DishType DishType { get; set; }

        public string DrinkTypeId { get; set; }

        public DrinkType DrinkType { get; set; }

        public ICollection<Dish> Dishes { get; set; }

        public ICollection<Drink> Drinks { get; set; }

        public string MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}
