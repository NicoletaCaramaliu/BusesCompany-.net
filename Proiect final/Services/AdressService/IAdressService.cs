using Proiect_final.Models.Adress;

namespace Proiect_final.Services.AdressService
{
    public interface IAdressService
    {
        //get all adresses
        Task<IEnumerable<Adress>> GetAllAdresses();

        //create adress
        Task CreateAdress(Adress adress);

        //get adress by driver id
        Task<Adress> GetAdressByDriverId(Guid driverId);
    }
}
