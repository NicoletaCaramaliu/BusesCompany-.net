using Proiect_final.Data;
using Proiect_final.Models.Driver;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.DriverRepository
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context) : base(context)
        {

        }

    }
}
