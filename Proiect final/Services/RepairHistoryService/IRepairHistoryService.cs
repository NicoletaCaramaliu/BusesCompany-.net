using Proiect_final.Models.RepairHistory;

namespace Proiect_final.Services.RepairHistoryService
{
    public interface IRepairHistoryService
    {
        //get all repair histories
        Task<IEnumerable<RepairHistory>> GetAllRepairHistories();

        //create a repair history
        Task CreateRepairHistory(RepairHistory repairHistory);
        
        //get repair history by id
        Task<RepairHistory> GetRepairHistoryById(Guid id);

        //update repair history
        Task UpdateRepairHistory(RepairHistory repairHistory);

        //delete repair history
        Task DeleteRepairHistory(RepairHistory repairHistory);
    }
}
