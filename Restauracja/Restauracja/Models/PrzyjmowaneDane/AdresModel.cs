namespace Restauracja.Models.PrzyjmowaneDane
{
    public class AdresModel
    {
        public int Id { get; set; }
        public string Miejscowosc { get; set; }
        public int KodPocztowy { get; set; }
        public int Ulica { get; set; }
        public int NumerDomu { get; set; }
        public int RestauracjaId { get; set; }
    }
}
