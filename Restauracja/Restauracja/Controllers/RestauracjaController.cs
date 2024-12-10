using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restauracja.Interfaces.OperajeDodawaniaZasobu;
using Restauracja.Models.Database.Entities;
using Restauracja.Models.PrzyjmowaneDane;

namespace Restauracja.Controllers
{
    public class RestauracjaController : Controller
    {
        private IRestauracjaOperacjeCRUD _restauracja;

        public RestauracjaController(IRestauracjaOperacjeCRUD restauracja)
        {
            _restauracja = restauracja;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DodajRestauracje(RestauracjaModel daneRestauracji)
        {
            if (ModelState.IsValid)
            {
                var czyDodanoDane = _restauracja.DodajRestauracje(daneRestauracji);

                if (czyDodanoDane)
                {
                    return Ok();
                }
                return BadRequest();
                
            }
            return View(daneRestauracji);
        }
    }
}
