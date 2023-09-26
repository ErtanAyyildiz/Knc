using Knc.DataAccess.Abstracts;
using Knc.DataAccess.Database;
using Knc.DataAccess.MsEntityFramework;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace RailwayStation.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Blog = new BlogDal(_db);
            Category = new CategoryDal(_db);
            ContactDetail = new ContactDetailDal(_db);
            Product = new ProductDal(_db);
            SubCategory = new SubCategoryDal(_db);
        }

        public IBlogDal Blog { get; private set; }

        public ICategoryDal Category { get; private set; }

        public IContactDetailDal ContactDetail { get; private set; }

        public IProductDal Product { get; private set; }

        public ISubCategoryDal SubCategory { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
