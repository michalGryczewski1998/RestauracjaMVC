using Microsoft.AspNetCore.Mvc;
using Restauracja.Models.Database.Entities;

namespace Restauracja.Controllers
{
    public class RestauracjaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DodajRestauracje(DaneRestauracji daneRestauracji)
        {
            if (ModelState.IsValid)
            {
                return View("Poprawne dane");
            }
            return View(daneRestauracji);
        }
    }
}
