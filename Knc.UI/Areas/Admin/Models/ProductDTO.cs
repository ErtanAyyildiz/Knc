namespace Knc.UI.Areas.Admin.Models
{
    public class ProductDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ProductImage { get; set; }
        public string? ImageUrl { get; set; }
        public int SubCategoryId { get; set; }
    }
}
