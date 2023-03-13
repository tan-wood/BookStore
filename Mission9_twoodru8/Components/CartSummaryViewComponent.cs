using Microsoft.AspNetCore.Mvc;
using Mission9_twoodru8.Model;
namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart c)
        {
            cart = c;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}