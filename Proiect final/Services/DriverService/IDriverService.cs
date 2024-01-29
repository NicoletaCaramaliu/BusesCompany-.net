using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;

namespace Proiect_final.Services.DriverService
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAllDrivers();

        //create driver
        Task<Driver> CreateDriver(Driver driver, Guid busId);

        Task<Driver> GetDriverById(Guid id);
        
        //update driver
        Task UpdateDriver(Driver driver);

        //delete driver
        Task DeleteDriver(Driver driver);

        //get drivers names ordered by age desc
        Task<List<string>> GetDriversNamesOrderedByAgeDesc();

    }
}
