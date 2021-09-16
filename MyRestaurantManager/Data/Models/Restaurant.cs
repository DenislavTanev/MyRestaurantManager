namespace MyRestaurantManager.Data.Models
{
    using MyRestaurantManager.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Restaurant : BaseDeletableModel<string>
    {
        public Restaurant()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
            this.Menus = new HashSet<Menu>();
            this.Orders = new HashSet<Order>();
            this.Tables = new HashSet<Table>();
        }

        public string Name { get; set; }

        public int Stars { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Menu> Menus { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}
