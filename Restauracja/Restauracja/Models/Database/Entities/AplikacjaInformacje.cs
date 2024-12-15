namespace Restauracja.Models.Database.Entities
{
    public class AplikacjaInformacje
    {
        public Guid Id { get; set; }
        public decimal WersjaAplikacji { get; set; }
        public DateTime DataWersji { get; set; }
        public string NazwaAplikacji { get; set; }
        public string Opis { get; set; }
    }
}
