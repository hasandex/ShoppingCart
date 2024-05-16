namespace SoppingCart.Services
{
    public interface IImageService
    {
        string StoreImage(IFormFile formFile, string path);
    }
}
