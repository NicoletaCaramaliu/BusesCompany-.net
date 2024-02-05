using Proiect_final.Models.Bus;
using Proiect_final.Repositories.GenericRepository;
using Proiect_final.Specification;

namespace Proiect_final.Repositories.BusRepository
{
    public interface IBusRepository : IGenericRepository<Bus>
    {
        Task<Bus> FindBusByIdAsync(Guid busId);
        Task<IEnumerable<Bus>> GetAllBusesAsync();
        Task<List<string>> GetBusesNumbersByCapacity(int capacity);

        List<Bus> GetBusesBySpecification(Specification<Bus> specification);
    }
}
