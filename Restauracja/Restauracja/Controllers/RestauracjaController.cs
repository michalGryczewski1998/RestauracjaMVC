using Microsoft.AspNetCore.Mvc;

namespace Restauracja.Controllers
{
    public class RestauracjaController : Controller
    {
        public IActionResult DodajRestauracje()
        {
            return View();
        }
    }
}
