namespace MyRestaurantManager.Data.Models
{
    using MyRestaurantManager.Data.Common;

    public class Image : BaseDeletableModel<int>
    {
        public byte[] Img { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}
