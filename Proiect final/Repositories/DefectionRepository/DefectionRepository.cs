using Proiect_final.Data;
using Proiect_final.Models.Defection;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.DefectionRepository
{
    public class DefectionRepository : GenericRepository<Defection>, IDefectionRepository
    {
        public DefectionRepository(ApiDbContext context) : base(context)
        {
        }

        
    }
}
