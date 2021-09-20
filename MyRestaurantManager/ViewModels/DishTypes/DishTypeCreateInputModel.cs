using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManager.ViewModels.DishTypes
{
    public class DishTypeCreateInputModel
    {
        [Required(ErrorMessage = "The field is required!")]
        [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
        [MaxLength(20, ErrorMessage = "The field must not be more than 20 characters!")]
        public string Name { get; set; }
    }
}
