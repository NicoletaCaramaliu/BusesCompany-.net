using Proiect_final.Data.UnitOfWork;
using Proiect_final.Models.Adress;
using Proiect_final.Models.Adress.DTO;
using Proiect_final.Repositories.AdressRepository;
using Proiect_final.Services.DriverService;

namespace Proiect_final.Services.AdressService
{
    public class AdressService : IAdressService
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdressService(IAdressRepository adressRepository, IUnitOfWork unitOfWork)
        { 
            _adressRepository = adressRepository;
            _unitOfWork = unitOfWork;
            
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
            await _unitOfWork.SaveAsync();
        }

        //get adress by driver id
        public async Task<Adress> GetAdressByDriverId(Guid id)
        {
            return await _adressRepository.GetAdressByDriverId(id);
        }

        //get adress by id
        public async Task<Adress> GetAdressById(Guid id)
        {
            return await _adressRepository.FindByIdAsync(id);
        }

        //update adress
        public async Task UpdateAdress(Adress adress)
        {
            _adressRepository.Update(adress);
            await _unitOfWork.SaveAsync();
        }

        //delete adress
        public async Task DeleteAdress(Adress adress)
        {
            _adressRepository.Delete(adress);
            await _unitOfWork.SaveAsync();
        }
    }
}
