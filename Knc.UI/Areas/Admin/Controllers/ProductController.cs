using Humanizer;
using Knc.DataAccess.Database;
using Knc.Entity.Modals;
using Knc.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace Knc.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }

        // GET: Product/Index
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.SubCategory).ToListAsync();
            return View(products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewBag.SubCategories = _unitOfWork.SubCategory.GetList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                if (productDTO.ProductImage != null && productDTO.ProductImage.Length > 0)
                {
                    // Dosya yükleme işlemi
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productDTO.ProductImage.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productDTO.ProductImage.CopyToAsync(stream);
                    }

                    // ImageUrl'i ayarla
                    productDTO.ImageUrl = "/images/" + fileName;
                }

                // ProductDTO verilerini kullanarak Product nesnesini oluşturun
                var product = new Product
                {
                    Title = productDTO.Title,
                    Description = productDTO.Description,
                    ImageUrl = productDTO.ImageUrl,
                    SubCategoryId = productDTO.SubCategoryId,
                    // Diğer özellikleri de ayarlayın
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Eğer ModelState geçersizse, hata durumunda View'e geri dön
            return View(productDTO);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Product.GetByID(id);
            // Ürünü bulun ve ProductDTO'ya çevirin
            var productDTO = new ProductEditDTO
            {
                Id=product.Id,
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                SubCategoryId = product.SubCategoryId
            };

            // Gerekirse alt kategori listesini doldurun
            ViewBag.SubCategories = _unitOfWork.SubCategory.GetSubCategories(product.SubCategoryId);


            return View(productDTO);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = _unitOfWork.Product.GetByID(productDTO.Id);
                if (productDTO.ProductImage != null && productDTO.ProductImage.Length > 0 && productDTO.ImageUrl != product.ImageUrl)
                {
                    // Dosya yükleme işlemi
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(productDTO.ProductImage.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        productDTO.ProductImage.CopyTo(stream);
                    }

                    // ImageUrl'i ayarla
                    productDTO.ImageUrl = "/images/" + fileName;
                    product.ImageUrl = productDTO.ImageUrl;
                }
                
                product.Title = productDTO.Title;
                product.SubCategoryId=productDTO.SubCategoryId;
                product.Description = productDTO.Description;

                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            // Eğer ModelState geçerli değilse, hata durumunda Edit View'e geri dönün
            return View(productDTO);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
