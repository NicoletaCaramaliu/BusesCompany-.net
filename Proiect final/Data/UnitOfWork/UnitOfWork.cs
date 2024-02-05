
using Proiect_final.Repositories.AdressRepository;
using Proiect_final.Repositories.BusRepository;
using Proiect_final.Repositories.DefectionRepository;
using Proiect_final.Repositories.DriverRepository;
using Proiect_final.Repositories.RepairHistoryRepository;

namespace Proiect_final.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBusRepository BusRepository { get; set;  }
        public IDriverRepository DriverRepository { get; set; }
        public IAdressRepository AdressRepository { get; set; }
        public IDefectionRepository DefectionRepository { get; set; }
        public IRepairHistoryRepository RepairHistoryRepository { get; set; }

        private ApiDbContext _context { get; set; }

        public UnitOfWork(ApiDbContext context, IBusRepository busRepository, IDriverRepository driverRepository,
            IAdressRepository adressRepository, IDefectionRepository defectionRepository, IRepairHistoryRepository repairHistoryRepository )
        {
            _context = context;
            BusRepository = busRepository;
            DriverRepository = driverRepository;
            AdressRepository = adressRepository;
            DefectionRepository = defectionRepository;
            RepairHistoryRepository = repairHistoryRepository;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() != 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
