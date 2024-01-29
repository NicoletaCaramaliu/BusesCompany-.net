using Proiect_final.Models.Adress;
using Proiect_final.Models.Adress.DTO;
using Proiect_final.Repositories.AdressRepository;
using Proiect_final.Services.DriverService;

namespace Proiect_final.Services.AdressService
{
    public class AdressService : IAdressService
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IDriverService _driverService;

        public AdressService(IAdressRepository adressRepository, IDriverService driverService)
        {
            _adressRepository = adressRepository;
            _driverService = driverService;
        }

        //get all adresses
        public async Task<IEnumerable<Adress>> GetAllAdresses()
        {
            return await _adressRepository.GetAllAsync();
        }

        //create adress
        public async Task CreateAdress(Adress adress)
        {
            await _adressRepository.CreateAsync(adress);
            await _adressRepository.SaveAsync();
        }

        //get adress by driver id
        public async Task<Adress> GetAdressByDriverId(Guid id)
        {
            return await _adressRepository.GetAdressByDriverId(id);
        }
    }
}
