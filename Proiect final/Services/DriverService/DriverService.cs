using Proiect_final.Models.Driver;
using Proiect_final.Repositories.DriverRepository;

namespace Proiect_final.Services.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        //get all drivers
        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            return await _driverRepository.GetAllAsync();
        }

        //create driver
        public async Task CreateDriver(Driver driver)
        {
            await _driverRepository.CreateAsync(driver);
            await _driverRepository.SaveAsync();
        }
    }
}
