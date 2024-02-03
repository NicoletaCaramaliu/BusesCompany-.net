using Proiect_final.Models.RepairHistory;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.RepairHistoryRepository
{
    public interface IRepairHistoryRepository : IGenericRepository<RepairHistory>
    {
        //get all repair history
        Task<IEnumerable<RepairHistory>> GetAllRepairHistoryAsync();

        //get repair history by id
        Task<RepairHistory> FindRHByIdAsync(Guid Id);





    }
}
