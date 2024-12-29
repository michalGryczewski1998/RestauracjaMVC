namespace Restauracja.Models.PrzyjmowaneDane
{
    [Serializable]
    public class RestauracjaModel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Zdjecie { get; set; }
        public bool CzyWypelnioneDaneAdres { get; set; }
        public bool CzyWypelnioneDaneDan { get; set; }
        public string Opis { get; set; }
        public string TypLokalu { get; set; }
        public string TypRestauracji { get; set; }
        public bool CzyDriveThru { get; set; }
        public bool CzyDostawa { get; set; }
        public bool CzyParkinPrzyRestauracji { get; set; }
        public bool CzyMozliwaRezerwacja { get; set; }
        public bool CzyImprezyOkolicznosciowe { get; set; }
        public bool CzySalaOkolicznosciowa { get; set; }
        public TimeSpan GodzinaOtwarcia { get; set; }
        public TimeSpan GodzinaZamkniecia { get; set; }
        public TimeSpan CzasOtwarcia { get; set; }
    }
}
