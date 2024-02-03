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
    }
}
