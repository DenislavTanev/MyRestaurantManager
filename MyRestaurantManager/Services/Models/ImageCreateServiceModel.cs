namespace MyRestaurantManager.Services.Models
{
    public class ImageCreateServiceModel
    {
        public byte[] Img { get; set; }

        public string DishId { get; set; }

        public string DrinkId { get; set; }

        public string RestaurantId { get; set; }
    }
}
