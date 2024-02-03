using Proiect_final.Models.RepairHistory;
using Proiect_final.Repositories.RepairHistoryRepository;

namespace Proiect_final.Services.RepairHistoryService
{
    public class RepairHistoryService : IRepairHistoryService
    {
        private readonly IRepairHistoryRepository _repairHistoryRepository;
        public RepairHistoryService(IRepairHistoryRepository repairHistoryRepository)
        {
            _repairHistoryRepository = repairHistoryRepository;
        }

        //get all repair histories
        public async Task<IEnumerable<RepairHistory>> GetAllRepairHistories()
        {
            return await _repairHistoryRepository.GetAllAsync();
        }

        //create repair history
        public async Task CreateRepairHistory(RepairHistory repairHistory)
        {
            await _repairHistoryRepository.CreateAsync(repairHistory);
            await _repairHistoryRepository.SaveAsync();
        }
    }
}
