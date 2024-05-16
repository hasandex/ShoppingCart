using Microsoft.AspNetCore.Mvc.Rendering;

namespace SoppingCart.Repo.Base
{
    public interface ICategoryRepo
    {
        IEnumerable<SelectListItem> GetCategoriesSelectList();
    }
}
