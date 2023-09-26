using Knc.DataAccess.Wrappers.Filters;
using Knc.Entity.Modals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace Knc.UI.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index(int Id)
        {
            PaginationFilter paginationFilter = new PaginationFilter(1, 12);
            var products = _unitOfWork.Product.GetProductsByCategoryId(Id, paginationFilter);
            var subCategories=_unitOfWork.SubCategory.GetSubCategoriesByCategoryId(Id);
            ViewBag.SubCategories = subCategories;
            return View(products);
        }

        [HttpPost]
        public IActionResult GetSelectedProducts(List<int> selectedSubCategoryIds)
        {
            // Seçili alt kategorilerin ürünlerini getir
            PaginationFilter paginationFilter = new PaginationFilter(1, 12);

            var selectedProducts = _unitOfWork.Product.SelectedProducts(selectedSubCategoryIds, paginationFilter);
            
            ViewBag.SubCategories = _unitOfWork.SubCategory.GetSubCategoriesByCategoryId(selectedProducts[0].SubCategory.CategoryId);

            return View("Index", selectedProducts);
        }
    }
}
