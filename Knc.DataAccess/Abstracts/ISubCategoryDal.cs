using Knc.Entity.Modals;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace Knc.DataAccess.Abstracts
{
    public interface ISubCategoryDal:IRepository<SubCategory>
    {
        public List<SubCategory> GetSubCategoriesByCategoryId(int categoryId);
        public List<SubCategory> GetSubCategories(int Id);

    }
}
