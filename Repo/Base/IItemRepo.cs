using SoppingCart.Models;

namespace SoppingCart.Repo.Base
{
    public interface IItemRepo
    {
        Task<IEnumerable<Item>> GetAll();
        int Create(CreateItemViewModel viewModel);
    }
}
