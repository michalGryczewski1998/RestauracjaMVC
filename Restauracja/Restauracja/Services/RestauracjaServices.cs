﻿using Restauracja.Interfaces.OperajeDodawaniaZasobu;
using Restauracja.Models.Database;
using Restauracja.Models.Database.Entities;
using Restauracja.Models.PrzyjmowaneDane;

namespace Restauracja.Services
{
    public class RestauracjaServices : IRestauracjaOperacjeCRUD
    {
        private readonly RestauracjaDbContext _restauracjaDbContext = new();
        public RestauracjaServices()
        {
           //dodaj wstrzykniecie dbContext !!!     
        }
        public bool DodajRestauracje(RestauracjaModel model)
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

        public bool EdytujRestauracje(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UsunRestauracje(int Id)
        {
            throw new NotImplementedException();
        }

        public bool WyswietlRestauracje(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
