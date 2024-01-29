using Proiect_final.Models.Driver;

namespace Proiect_final.Services.DriverService
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAllDrivers();

        Task CreateDriver(Driver driver);
    }
}
