using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restauracja.Interfaces.OperajeDodawaniaZasobu;
using Restauracja.Models.Database.Entities;
using Restauracja.Models.PrzyjmowaneDane;

namespace Restauracja.Controllers
{
    public class RestauracjaController : Controller
    {
        private readonly IRestauracjaOperacjeCRUD _restauracja;

        public RestauracjaController(IRestauracjaOperacjeCRUD restauracja)
        {
            _restauracja = restauracja;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Przegladaj()
        {
            var czyDoWyswietlenia = await _restauracja.WyswietlRestauracje();

            if (czyDoWyswietlenia != null)
            {
                return View(czyDoWyswietlenia);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> RestauracjaDetails(int Id)
        {
            if (Id == 0)
            {
                return BadRequest(ModelState);
            }

            var restauracja = await _restauracja.WyswietlKonkretnaRestauracje(Id);
            if (restauracja == null)
            {
                return BadRequest();
            }
            return View(restauracja);
        }

        [HttpPost]
        public async Task<IActionResult> DodajRestauracje(RestauracjaModel daneRestauracji)
        {
            if (ModelState.IsValid)
            {
                var czyDodanoDane = await _restauracja.DodajRestauracje(daneRestauracji);

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
