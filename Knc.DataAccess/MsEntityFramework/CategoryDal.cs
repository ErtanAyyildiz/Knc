using Knc.DataAccess.Abstracts;
using Knc.DataAccess.Database;
using Knc.Entity.Modals;
using RailwayStation.DataAccess.Repositories;

namespace Knc.DataAccess.MsEntityFramework
{
    public class CategoryDal:Repository<Category>,ICategoryDal
    {
        private readonly AppDbContext _db;

        public CategoryDal(AppDbContext db) : base(db)
        {
            _db=db;
        }
    }
}
