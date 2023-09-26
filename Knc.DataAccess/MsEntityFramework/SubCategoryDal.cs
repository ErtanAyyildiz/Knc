using Knc.DataAccess.Abstracts;
using Knc.DataAccess.Database;
using Knc.Entity.Modals;
using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Repositories;

namespace Knc.DataAccess.MsEntityFramework
{
    public class SubCategoryDal:Repository<SubCategory>,ISubCategoryDal
    {
        private readonly AppDbContext _db;

        public SubCategoryDal(AppDbContext db) : base(db)
        {
            _db=db;
        }

        public List<SubCategory> GetSubCategoriesByCategoryId(int categoryId)
        {
            return _db.SubCategories
                .Where(s => s.CategoryId == categoryId)
                .ToList();
        }

        public List<SubCategory> GetSubCategories(int Id)
        {
            return _db.SubCategories.Include(s => s.Products).Include(s => s.Category).Where(s => s.Id == Id).ToList();
        }
    }
}
