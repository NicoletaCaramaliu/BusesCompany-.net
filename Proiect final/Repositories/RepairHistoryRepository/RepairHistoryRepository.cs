using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models.RepairHistory;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.RepairHistoryRepository
{
    public class RepairHistoryRepository : GenericRepository<RepairHistory>, IRepairHistoryRepository
    {
        public RepairHistoryRepository(ApiDbContext context) : base(context)
        {
        }

        //get all repair hitory
        public async Task<IEnumerable<RepairHistory>> GetAllRepairHistoryAsync()
        {
            return await _table
                .Include(r => r.Bus)
                .Include(r => r.Defection)
                .ToListAsync();
        }

        //get repair history by bus id
        public async Task<RepairHistory> FindRHByIdAsync(Guid Id)
        {
            return await _table
                .Include(r => r.Bus)
                .Include(r => r.Defection)
                .FirstOrDefaultAsync(r => r.Id == Id);
        }


    }
}
