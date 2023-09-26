using Knc.DataAccess.Abstracts;
using Knc.DataAccess.Database;
using Knc.DataAccess.Wrappers.Filters;
using Knc.Entity.Modals;
using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Repositories;

namespace Knc.DataAccess.MsEntityFramework
{
    public class ProductDal:Repository<Product>,IProductDal
    {
        private readonly AppDbContext _db;

        public ProductDal(AppDbContext db) : base(db)
        {
            _db=db;
        }



        public List<Product> GetProductsByCategoryId(int categoryId, PaginationFilter filter)
        {
            var category = _db.Categories
            .Include(c => c.SubCategories)
                .ThenInclude(sc => sc.Products)
            .FirstOrDefault(c => c.Id == categoryId);

            
            if (category == null)
            {
                // Kategori bulunamadı
                return null;
            }

            // Belirli kategoriye ait tüm ürünleri topluyoruz
            var products = category.SubCategories.SelectMany(sc => sc.Products).Skip((filter.PageNumber -1) * filter.PageSize).Take(filter.PageSize).ToList();

            return products;
        }

        public List<Product> SelectedProducts(List<int> selectedSubCategoryIds, PaginationFilter filter)
        {
            return _db.Products.Include(p=>p.SubCategory).ThenInclude(p=>p.Category)
            .Where(p => selectedSubCategoryIds.Contains(p.SubCategoryId))
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();
        }
    }
}
