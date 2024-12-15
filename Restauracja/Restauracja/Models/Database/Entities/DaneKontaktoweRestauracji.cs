namespace Restauracja.Models.Database.Entities
{
    public class DaneKontaktoweRestauracji
    {
        public int Id { get; set; }
        public string NumerTelefonu { get; set; }
        public string? StronaInternetowa { get; set; }
        public string? Instagram { get; set; }
        public int RestauracjaId { get; set; }
        public DaneRestauracji DaneRestauracji { get; set; }
    }
}
