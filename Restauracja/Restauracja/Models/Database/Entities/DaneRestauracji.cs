namespace Restauracja.Models.Database.Entities
{
    public class DaneRestauracji
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string TypLokalu { get; set; }
        public string TypRestauracji { get; set; }
        public bool CzyDriveThru { get; set; }
        public bool CzyDostawa { get; set; }
        public bool CzyParkinPrzyRestauracji { get; set; } = false;
        public bool CzyMozliwaRezerwacja { get; set; }
        public bool CzyImprezyOkolicznosciowe { get; set; }
        public bool CzySalaOkolicznosciowa { get; set; }
        public TimeSpan GodzinaOtwarcia { get; set; }
        public TimeSpan GodzinaZamkniecia { get; set; }
        public TimeSpan CzasOtwarcia { get; set; }
        public List<AdresRestauracji> Adres { get; set; }
        public List<DaniaRestauracji> DaniaRestauracji { get; set; }
        public DaneKontaktoweRestauracji DaneKontaktoweRestauracji { get; set; }

    }
}
