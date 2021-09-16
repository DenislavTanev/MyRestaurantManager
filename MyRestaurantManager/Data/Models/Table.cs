namespace MyRestaurantManager.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyRestaurantManager.Data.Common;

    public class Table : BaseDeletableModel<string>
    {
        public Table()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public int Number { get; set; }

        public ICollection<Order> Orders { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
