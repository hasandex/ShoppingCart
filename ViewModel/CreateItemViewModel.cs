using Microsoft.AspNetCore.Mvc.Rendering;
using SoppingCart.CustomDataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace SoppingCart.ViewModel
{
    public class CreateItemViewModel
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number")]
        public double Price { get; set; } = 0;
        [MaxFileSize(Settings.MaxImgSize)]
        [AllowedExtension(Settings.AllowedImgExtensions)]
        public IFormFile FormFile { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoriesSelectList { get; set; } = new List<SelectListItem>();

    }
}
