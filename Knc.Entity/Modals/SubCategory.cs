using System.ComponentModel.DataAnnotations;

namespace Knc.Entity.Modals
{
    public class SubCategory
    {
        public int Id { get; set; } //koç sistem koça bağlı
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
