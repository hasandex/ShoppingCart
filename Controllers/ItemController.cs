using Microsoft.AspNetCore.Mvc;
using SoppingCart.Repo.Base;

namespace SoppingCart.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepo _itemRepo;
        private readonly ICategoryRepo _categoryRepo;
        public ItemController(IItemRepo itemRepo, ICategoryRepo categoryRepo)
        {
            _itemRepo = itemRepo;
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _itemRepo.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateItemViewModel()
            {
                CategoriesSelectList = _categoryRepo.GetCategoriesSelectList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateItemViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.CategoriesSelectList = _categoryRepo.GetCategoriesSelectList();
                return View(viewModel);
            }
            var isCreated = _itemRepo.Create(viewModel);
            if(isCreated == 0)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
