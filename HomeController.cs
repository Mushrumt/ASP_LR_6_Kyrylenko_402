using Microsoft.AspNetCore.Mvc;

namespace ASP_LR_6_Kyrylenko_402
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Order(User user)
        {
            if (user.Age > 16)
            {
                return RedirectToAction("OrderProducts", user);
            }
            else
            {
                return View("Underage");
            }
        }

        public IActionResult OrderProducts(User user)
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult ConfirmOrder(User user, List<Product> products)
        {
            // Process the order and display information
            if (products != null && products.Count > 0)
            {
                return View(products);
            }
            else
            {
                ModelState.AddModelError("", "Please order at least one product.");
                return View("OrderProducts", user);
            }
        }
    }
}
