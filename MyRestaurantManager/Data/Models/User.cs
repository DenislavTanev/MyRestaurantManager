namespace MyRestaurantManager.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string StaffId { get; set; }

        public RestaurantStaff RestaurantStaff { get; set; }
    }
}
