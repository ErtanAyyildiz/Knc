using Knc.DataAccess.Abstracts;
using Knc.DataAccess.Database;
using Knc.Entity.Modals;
using RailwayStation.DataAccess.Repositories;

namespace Knc.DataAccess.MsEntityFramework
{
    public class BlogDal : Repository<Blog>, IBlogDal
    {
        private readonly AppDbContext _db;
        public BlogDal(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
