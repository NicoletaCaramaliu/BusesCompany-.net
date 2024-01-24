using Proiect_final.Data;
using Proiect_final.Models.Bus;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.BusRepository
{
    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        public BusRepository(ApiDbContext context) : base(context)
        {

        }
        //order buses descending by capacity

    }
}
