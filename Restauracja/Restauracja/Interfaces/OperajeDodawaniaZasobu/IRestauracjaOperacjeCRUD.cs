using Restauracja.Models.PrzyjmowaneDane;

namespace Restauracja.Interfaces.OperajeDodawaniaZasobu
{
    public interface IRestauracjaOperacjeCRUD
    {
        public Task<bool> DodajRestauracje(RestauracjaModel model);
        public Task<bool> UsunRestauracje(int Id);
        public Task<bool> EdytujRestauracje(int Id);
        public Task<List<RestauracjaModel>> WyswietlRestauracje();
    }
}
