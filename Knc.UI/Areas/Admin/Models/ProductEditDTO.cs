namespace Knc.UI.Areas.Admin.Models
{
    public class ProductEditDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? ProductImage { get; set; }
        public string? ImageUrl { get; set; }
        public int SubCategoryId { get; set; }
    }
}
