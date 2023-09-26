using Knc.DataAccess;
using Knc.DTO.DTOs.Baskets;
using Knc.Entity.Modals;
using Knc.UI.ViewComponents.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace Knc.UI.Controllers
{
    [AllowAnonymous]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartDTO cartDTO = new()
            {
                CartItems = cart
            };
            return View(cartDTO);
        }

        public IActionResult Add(int Id, int quantity=1)
        {
            if (quantity<1)
            {
                quantity = 1;
            }
            Product product = _unitOfWork.Product.GetByID(Id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product, quantity));
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Başarılı"] = "Ürün Eklendi";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }
    }
}
