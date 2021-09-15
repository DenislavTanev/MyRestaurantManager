namespace MyRestaurantManager.Data.Models
{
    using MyRestaurantManager.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Table : BaseDeletableModel<int>
    {
        public int Number { get; set; }

        public IEnumerable<Order> Orders { get; init; } = new List<Order>();
    }
}
