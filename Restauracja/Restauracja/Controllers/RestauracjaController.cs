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
                daneRestauracji.Zdjecie = daneRestauracji.Zdjecie;
                var czyDodanoDane = await _restauracja.DodajRestauracje(daneRestauracji);

                if (czyDodanoDane)
                {
                    return Ok();
                }
                return BadRequest();
                
            }
            return View(daneRestauracji);
        }

        [HttpGet]
        public async Task<IActionResult> DodajAdres(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            ViewData["RestauracjaId"] = Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ZapiszAdres(AdresModel daneAdresowe)
        {
            if (ModelState.IsValid)
            {
                var czyDodanoAdres = await _restauracja.DodajAdresDlaRestauracji(daneAdresowe);

                if (czyDodanoAdres)
                {
                    return Redirect("/Home/Index");
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}

