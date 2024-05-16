using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using SoppingCart.Data;
using SoppingCart.Models;
using SoppingCart.Repo.Base;
using SoppingCart.Services;

namespace SoppingCart.Repo
{
    public class ItemRepo : IItemRepo
    {
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _appDbContext;
        public ItemRepo(AppDbContext appDbContext, IWebHostEnvironment env,IImageService imageService)
        {
            _appDbContext = appDbContext;
            _env = env;
            _imageService = imageService;
        }

        public int Create(CreateItemViewModel viewModel)
        {
            var item = new Item()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId,
                Price = viewModel.Price,
                Cover = _imageService.StoreImage(viewModel.FormFile,Settings.ItemImageStorePath),
            };
            _appDbContext.Items.Add(item);
            return _appDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _appDbContext.Items.Include(i => i.Category).AsNoTracking().ToListAsync();
        }
    }
}
