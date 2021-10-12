using System.ComponentModel.DataAnnotations;

namespace MyRestaurantManager.ViewModels.Restaurants
{
    public class RestaurantCreateInputModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be more than 2 characters.")]
        public string Name { get; set; }

        public int Stars { get; set; }
    }
}
