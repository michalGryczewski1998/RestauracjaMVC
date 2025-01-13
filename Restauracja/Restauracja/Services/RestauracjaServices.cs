using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DodajAdresDlaRestauracji(AdresModel adresModel)
        {
            if (adresModel != null)
            {
                var modelAdresu = new AdresRestauracji
                {
                    Miejscowosc = adresModel.Miejscowosc,
                    KodPocztowy = adresModel.KodPocztowy,
                    Ulica = adresModel.Ulica,
                    NumerDomu = adresModel.NumerDomu,
                    RestauracjaId = adresModel.RestauracjaId
                };

                await _restauracjaDbContext.AdresRestauracji.AddAsync(modelAdresu);

                int czyDodano = await _restauracjaDbContext.SaveChangesAsync();

                if (czyDodano > 0)
                {
                    bool status = await AktualizujPozycjeRestauracji(adresModel.RestauracjaId);

                    if (status)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<bool> DodajRestauracje(RestauracjaModel model)
        {
            if(model != null)
            {
                var modelRestauracji = new DaneRestauracji 
                {
                    Nazwa = model.Nazwa,
                    Zdjecie = model.Zdjecie,
                    CzyWypelnioneDaneAdres = false,
                    CzyWypelnioneDaneDan = false,
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

                _restauracjaDbContext.Restauracjas.Add(modelRestauracji);
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

        public async Task<RestauracjaModel> WyswietlKonkretnaRestauracje(int Id)
        {
            RestauracjaModel model = new();
            if (Id == 0)
                return model;

            var restauracjaSzukana = await _restauracjaDbContext.Restauracjas.FirstOrDefaultAsync(x => x.Id == Id);

            if (restauracjaSzukana != null)
            {
                model.Id = restauracjaSzukana.Id;
                model.Nazwa = restauracjaSzukana.Nazwa;
                model.Opis = restauracjaSzukana.Opis;
                model.TypLokalu = restauracjaSzukana.TypLokalu;
                model.TypRestauracji = restauracjaSzukana.TypRestauracji;
                model.CzasOtwarcia = restauracjaSzukana.CzasOtwarcia;
                model.CzyDriveThru = restauracjaSzukana.CzyDriveThru;
                model.CzyDostawa =  restauracjaSzukana.CzyDostawa;
                model.CzyImprezyOkolicznosciowe = restauracjaSzukana.CzyImprezyOkolicznosciowe;
                model.CzyMozliwaRezerwacja = restauracjaSzukana.CzyMozliwaRezerwacja;
                model.CzyParkinPrzyRestauracji = restauracjaSzukana.CzyParkinPrzyRestauracji;
                model.CzySalaOkolicznosciowa = restauracjaSzukana.CzySalaOkolicznosciowa;
                model.CzyWypelnioneDaneAdres = restauracjaSzukana.CzyWypelnioneDaneAdres;
            }
            
            return model;
        }

        public async Task<List<RestauracjaModel>> WyswietlRestauracje()
        {
            List<RestauracjaModel> restauracja = [];
            List<DaneRestauracji> dane = [.. _restauracjaDbContext.Restauracjas];

            if (dane != null)
            {
                foreach (var item in dane)
                {
                    restauracja.Add(new RestauracjaModel
                    {
                        Id = item.Id,
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
                        CzySalaOkolicznosciowa = item.CzySalaOkolicznosciowa,
                        Zdjecie = item.Zdjecie
                    });
                }
            }

            return restauracja;

        }

        private async Task<bool> AktualizujPozycjeRestauracji(int restauracjaId)
        {
            // Znajdź restaurację w bazie danych
            var restauracja = await _restauracjaDbContext.Restauracjas.FindAsync(restauracjaId);
            if (restauracja == null)
            {
                return false;
            }

             restauracja.CzyWypelnioneDaneAdres = true;
            _restauracjaDbContext.Entry(restauracja).Property(r => r.CzyWypelnioneDaneAdres).IsModified = true;
            int czyDodano = _restauracjaDbContext.SaveChanges();

            if (czyDodano > 0)
            {
                return true;
            }
            return false;
        }
    }
}
