namespace Restauracja.Models.Database.Entities
{
    public class ParametryKonfiguracyjne
    {
        public int Id { get; set; }
        public bool CzyWlaczone { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime? DataWlaczenia { get; set; }
        public DateTime? DataDo { get; set; }
    }
}
