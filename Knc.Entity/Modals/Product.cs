using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knc.Entity.Modals
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int? StockAmount { get; set; }
        public bool? Availability { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? FinishDate { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

    }
}
