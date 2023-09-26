using Knc.DataAccess.Abstracts;

namespace RailwayStation.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IBlogDal Blog { get; }
        ICategoryDal Category { get; }
        IContactDetailDal ContactDetail { get; }
        IProductDal Product { get; }
        ISubCategoryDal SubCategory { get; }

        void Save();

    }
}
