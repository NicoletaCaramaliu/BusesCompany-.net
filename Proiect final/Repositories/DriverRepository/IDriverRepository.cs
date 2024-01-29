using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.DriverRepository
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver> CreateDriver(Driver driver, Guid busId);

        //get drivers names ordered by age desc 
        Task<List<string>> GetDriversNamesOrderedByAgeDesc();

    }
}
