namespace MyRestaurantManager.Services.Models
{
    public class DrinkDetailsServiceModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        public DrinkTypeServiceModel Type { get; set; }

        public ImageServiceModel Image { get; set; }
    }
}
