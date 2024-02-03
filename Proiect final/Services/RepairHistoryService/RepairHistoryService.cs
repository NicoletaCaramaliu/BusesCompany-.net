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
            return await _repairHistoryRepository.GetAllRepairHistoryAsync();
        }

        //create repair history
        public async Task CreateRepairHistory(RepairHistory repairHistory)
        {
            await _repairHistoryRepository.CreateAsync(repairHistory);
            await _repairHistoryRepository.SaveAsync();
        }

        //get repair history by id
        public async Task<RepairHistory> GetRepairHistoryById(Guid id)
        {
            return await _repairHistoryRepository.FindRHByIdAsync(id);
        }

        //update repair history
        public async Task UpdateRepairHistory(RepairHistory repairHistory)
        {
            _repairHistoryRepository.Update(repairHistory);
            await _repairHistoryRepository.SaveAsync();
        }

        //delete repair history
        public async Task DeleteRepairHistory(RepairHistory repairHistory)
        {
            _repairHistoryRepository.Delete(repairHistory);
            await _repairHistoryRepository.SaveAsync();
        }
    }
}
