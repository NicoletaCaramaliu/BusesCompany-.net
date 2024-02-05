using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models.Bus;
using Proiect_final.Repositories.GenericRepository;
using Proiect_final.Specification;

namespace Proiect_final.Repositories.BusRepository
{
    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        private readonly ApiDbContext _context;
        public BusRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Bus> FindBusByIdAsync(Guid busId)
        {
            return await _table
                .Include(b => b.Drivers)
                .Include(b => b.RepairHistories)
                .FirstOrDefaultAsync(b => b.Id == busId);
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _table
                .Include(b => b.Drivers)
                .Include(b => b.RepairHistories)
                .ThenInclude(r => r.Defection)
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

        public List<Bus> GetBusesBySpecification(Specification<Bus> specification)
        {
            return SpecificationQueryBuilder
                .GetQuery(_context.Buses, specification)
                .ToList();
        }



    }
    
}
