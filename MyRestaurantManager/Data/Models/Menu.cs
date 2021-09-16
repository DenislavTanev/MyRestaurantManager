namespace MyRestaurantManager.Data.Models
{
    using MyRestaurantManager.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Menu : BaseDeletableModel<string>
    {
        public Menu()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Sections = new HashSet<MenuSection>();
        }

        public string Title { get; set; }

        public ICollection<MenuSection> Sections { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
