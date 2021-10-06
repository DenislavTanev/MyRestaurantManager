namespace MyRestaurantManager.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using MyRestaurantManager.Data;
    using MyRestaurantManager.Data.Models;
    using MyRestaurantManager.Services.Interfaces;
    using MyRestaurantManager.Services.Models;

    public class ImagesService : IImagesService
    {
        private readonly MyRestaurantManagerDbContext _context;

        public ImagesService(MyRestaurantManagerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ImageCreateServiceModel input)
        {
            var image = new Image
            {
                Img = input.Img,
                DishId = input.DishId,
                DrinkId = input.DrinkId,
                RestaurantId = input.RestaurantId,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
            };

            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);

            if (image != null)
            {
                image.IsDeleted = true;
                image.DeletedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(ImageServiceModel input)
        {
            var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (image != null)
            {
                image.Img = input.Img;
                image.ModifiedOn = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public ImageServiceModel GetById(string id)
        {
            var img = _context.Images
                .Where(x => x.Id == id)
                .Select(x => new ImageServiceModel
                {
                    Id = x.Id,
                    Img = x.Img,
                })
                .FirstOrDefault();

            return img;
        }

        public IEnumerable<ImageServiceModel> GetByRestaurant(string restaurantId)
        {
            var imgs = _context.Images
                .Where(x => x.Id == restaurantId)
                .Select(x => new ImageServiceModel
                {
                    Id = x.Id,
                    Img = x.Img,
                })
                .ToList();

            return imgs;
        }
    }
}
