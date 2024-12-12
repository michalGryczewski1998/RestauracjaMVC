using Restauracja.Interfaces.OperajeDodawaniaZasobu;
using Restauracja.Models.Database;
using Restauracja.Models.Database.Entities;
using Restauracja.Models.PrzyjmowaneDane;
using System.Linq;

namespace Restauracja.Services
{
    public class RestauracjaServices : IRestauracjaOperacjeCRUD
    {
        private readonly RestauracjaDbContext _restauracjaDbContext = new();
        public RestauracjaServices()
        {
           //dodaj wstrzykniecie dbContext !!!     
        }
        public async Task<bool> DodajRestauracje(RestauracjaModel model)
        {
            if(model != null)
            {
                var modelRestauracji = new DaneRestauracji 
                {
                    Nazwa = model.Nazwa,
                    Opis = model.Opis,
                    TypLokalu = model.TypLokalu,
                    TypRestauracji = model.TypRestauracji,
                    CzyDriveThru = model.CzyDriveThru,
                    CzyDostawa = model.CzyDostawa,
                    CzyParkinPrzyRestauracji = model.CzyParkinPrzyRestauracji,
                    CzyMozliwaRezerwacja = model.CzyMozliwaRezerwacja,
                    CzyImprezyOkolicznosciowe = model.CzyImprezyOkolicznosciowe,
                    CzySalaOkolicznosciowa = model.CzySalaOkolicznosciowa,
                    GodzinaOtwarcia = model.GodzinaOtwarcia,
                    GodzinaZamkniecia = model.GodzinaZamkniecia,
                    CzasOtwarcia = model.CzasOtwarcia,
                };

                _restauracjaDbContext.restauracjas.Add(modelRestauracji);
                int czyDodano = _restauracjaDbContext.SaveChanges();

                if (czyDodano > 0)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public async Task<bool> EdytujRestauracje(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UsunRestauracje(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RestauracjaModel>> WyswietlRestauracje()
        {
            List<RestauracjaModel> restauracja = [];
            List<DaneRestauracji> dane = [.. _restauracjaDbContext.restauracjas];

            if (dane != null)
            {
                foreach (var item in dane)
                {
                    restauracja.Add(new RestauracjaModel
                    {
                        Nazwa = item.Nazwa,
                        Opis = item.Opis,
                        TypLokalu = item.TypLokalu,
                        TypRestauracji = item.TypRestauracji,
                        CzasOtwarcia = item.CzasOtwarcia,
                        CzyDriveThru = item.CzyDriveThru,   
                        CzyDostawa = item.CzyDostawa,
                        CzyImprezyOkolicznosciowe = item.CzyImprezyOkolicznosciowe,
                        CzyMozliwaRezerwacja = item.CzyMozliwaRezerwacja,
                        CzyParkinPrzyRestauracji = item.CzyParkinPrzyRestauracji,
                        CzySalaOkolicznosciowa = item.CzySalaOkolicznosciowa
                    });
                }
            }

            return restauracja;

        }
    }
}
