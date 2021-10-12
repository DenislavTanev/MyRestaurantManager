using MyRestaurantManager.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Data.Models
{
    public class RestaurantStaff : BaseModel<string>
    {
        public RestaurantStaff()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Staff = new HashSet<User>();
        }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<User> Staff { get; set; }
    }
}
