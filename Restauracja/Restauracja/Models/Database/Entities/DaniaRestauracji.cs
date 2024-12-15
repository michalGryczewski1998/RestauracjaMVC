namespace Restauracja.Models.Database.Entities
{
    public class DaniaRestauracji
    {
        public int Id { get; set; }
        public string Zdjecie { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int Kalorycznosc { get; set; }
        public string Informacje { get; set; }
        public int RestauracjaID { get; set; }
        public DaneRestauracji DaneRestauracji { get; set; }
    }
}
