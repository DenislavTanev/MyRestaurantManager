using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.Services.Models
{
    public class RestaurantServiceModel
    {
        public string Name { get; set; }

        public int Stars { get; set; }

        public ICollection<ImageServiceModel> Images { get; set; }
    }
}
