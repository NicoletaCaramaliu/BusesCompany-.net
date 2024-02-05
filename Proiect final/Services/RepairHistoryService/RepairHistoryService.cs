using Proiect_final.Data.UnitOfWork;
using Proiect_final.Models.RepairHistory;
using Proiect_final.Repositories.RepairHistoryRepository;

namespace Proiect_final.Services.RepairHistoryService
{
    public class RepairHistoryService : IRepairHistoryService
    {
        private readonly IRepairHistoryRepository _repairHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RepairHistoryService(IRepairHistoryRepository repairHistoryRepository, IUnitOfWork unitOfWork)
        {
            _repairHistoryRepository = repairHistoryRepository;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.SaveAsync();
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
            await _unitOfWork.SaveAsync();
        }

        //delete repair history
        public async Task DeleteRepairHistory(RepairHistory repairHistory)
        {
            _repairHistoryRepository.Delete(repairHistory);
            await _repairHistoryRepository.SaveAsync();
        }
    }
}
