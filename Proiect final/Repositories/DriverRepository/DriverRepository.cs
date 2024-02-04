using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;
using Proiect_final.Repositories.BusRepository;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.DriverRepository
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public DriverRepository(ApiDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public DriverRepository(ApiDbContext context) : base(context)
        {

        }
        //get all drivers   
        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _table
                .Include(d => d.Bus)
                .Include(d => d.Adress)
                .ToListAsync();
        }

        public async Task<Driver> CreateDriver(Driver driver, Guid busId)
        {
            var bus = await _context.Buses.FindAsync(busId);


            if (bus == null)
            {
                return null; 
            }

            driver.Bus = bus;
            //create driver
            await CreateAsync(driver);
            await SaveAsync();

            return driver;
        }

        //get drivers names ordered by age desc, if they have the same age, order them by name asc
        public async Task<List<string>> GetDriversNamesOrderedByAgeDesc()
        {
            var driversNames = from driver in _table
                               orderby driver.Age descending, driver.Name ascending
                               select driver.Name;

            return await driversNames.ToListAsync();
        }

        //function using join to get the defection names of the bus the driver is driving
        public async Task<List<string>> GetDefectionNamesByDriverId(Guid driverId)
        {
            var defectionNames = from driver in _table
                                 join bus in _context.Buses on driver.BusId equals bus.Id
                                 join repairHistory in _context.RepairHistories on bus.Id equals repairHistory.BusId
                                 join defection in _context.Defections on repairHistory.DefectionId equals defection.Id
                                 where driver.Id == driverId
                                 select defection.DefectionName;

            return await defectionNames.ToListAsync();
        }

    }
}
