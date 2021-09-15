namespace MyRestaurantManager.Data.Models
{
    using MyRestaurantManager.Data.Common;

    public class Drink : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        public int TypeId { get; set; }

        public DrinkType Type { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
