using Proiect_final.Models.Adress;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.AdressRepository
{
    public interface IAdressRepository : IGenericRepository<Adress>
    {
        //get adress by driver id
        Task<Adress> GetAdressByDriverId(Guid driverId);
    }

}
