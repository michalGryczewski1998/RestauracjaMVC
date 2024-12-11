using Restauracja.Models.PrzyjmowaneDane;

namespace Restauracja.Interfaces.OperajeDodawaniaZasobu
{
    public interface IRestauracjaOperacjeCRUD
    {
        public bool DodajRestauracje(RestauracjaModel model);
        public bool UsunRestauracje(int Id);
        public bool EdytujRestauracje(int Id);
        public RestauracjaModel WyswietlRestauracje(int Id);
    }
}
