using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models.Bus;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.BusRepository
{
    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        public BusRepository(ApiDbContext context) : base(context)
        {

        }

        public async Task<Bus> FindBusByIdAsync(Guid busId)
        {
            return await _table
                .Include(b => b.Drivers)
                .FirstOrDefaultAsync(b => b.Id == busId);
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _table
                .Include(b => b.Drivers)
                .ToListAsync();
        }

        //get buses by capacity
        public async Task<List<string>> GetBusesNumbersByCapacity(int capacity)
        {
            var busNumbers = from bus in _table
                             where bus.Capacity == capacity
                             select bus.Number;
            
            return await busNumbers.ToListAsync();
        }
    }
    
}
