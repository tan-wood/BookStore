using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twoodru8.Model;

namespace Mission9_twoodru8.Controllers
{
    public class PaymentController : Controller
    {
        private  IPaymentRepository repo { get; set; }
        private Cart cart { get; set; }
        public PaymentController(IPaymentRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Payment());
        }

        [HttpPost]
        public IActionResult Checkout(Payment payment)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");

            }

            if (ModelState.IsValid)
            {
                payment.Lines = cart.Items.ToArray();
                repo.SavePayment(payment);
                cart.ClearCart();
                return RedirectToPage("/PaymentCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
