namespace MyRestaurantManager.Services.Models
{
    public class DrinkCreateServiceModel
    {
        public string Name { get; set; }

        public string PortionQuantity { get; set; }

        public decimal Price { get; set; }

        public DrinkTypeServiceModel Type { get; set; }

        public byte[] Image { get; set; }
    }
}
