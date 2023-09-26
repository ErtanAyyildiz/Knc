using Knc.DataAccess.Wrappers.Filters;
using Knc.Entity.Modals;
using RailwayStation.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knc.DataAccess.Abstracts
{
    public interface IProductDal:IRepository<Product>
    {
        public List<Product> GetProductsByCategoryId(int categoryId, PaginationFilter filter);

        public List<Product> SelectedProducts(List<int> selectedSubCategoryIds, PaginationFilter filter);

    }
}
