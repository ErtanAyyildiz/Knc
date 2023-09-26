using Knc.DataAccess;
using Knc.DTO.DTOs.Baskets;
using Knc.Entity.Modals;
using Microsoft.AspNetCore.Mvc;

namespace Knc.UI.ViewComponents.Basket
{
    public class SmallCart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");


            SmallCartDTO smallCartVM;

            if (cart == null || cart.Count == 0)
            {
                smallCartVM = null;
            }
            else
            {
                var uniqueProductIds = cart.Select(item => item.ProductId).Distinct();
                smallCartVM = new()
                {
                    NumberOfItems = uniqueProductIds.Count()
            };
            }

            return View(smallCartVM);
        }
    }
}
