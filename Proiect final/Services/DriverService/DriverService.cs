using Microsoft.EntityFrameworkCore;
using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;
using Proiect_final.Repositories.AdressRepository;
using Proiect_final.Repositories.DriverRepository;

namespace Proiect_final.Services.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IAdressRepository _adressRepository;

        public DriverService(IDriverRepository driverRepository, IAdressRepository adressRepository)
        {
            _driverRepository = driverRepository;
            _adressRepository = adressRepository;
        }

        //get all drivers
        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            return await _driverRepository.GetAllDriversAsync();
        }

        //create driver
        public async Task<Driver> CreateDriver(Driver driver, Guid busId)
        {
            return await _driverRepository.CreateDriver(driver, busId);
        }

        //get driver by id
        public async Task<Driver> GetDriverById(Guid id)
        {
            return await _driverRepository.FindByIdAsync(id);
        }

        //update driver
        public async Task UpdateDriver(Driver driver)
        {
            _driverRepository.Update(driver);
            await _driverRepository.SaveAsync();
        }

        //delete driver
        public async Task DeleteDriver(Driver driver)
        {
            _driverRepository.Delete(driver);
            await _driverRepository.SaveAsync();
        }

        //get drivers names ordered by age desc
        public async Task<List<string>> GetDriversNamesOrderedByAgeDesc()
        {
            return await _driverRepository.GetDriversNamesOrderedByAgeDesc();
        }

        //get defection names 
        public async Task<List<string>> GetDefectionNames(Guid driverId)
        {
            return await _driverRepository.GetDefectionNamesByDriverId(driverId);
        }
    }

}

