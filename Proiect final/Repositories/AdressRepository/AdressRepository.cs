using Microsoft.EntityFrameworkCore;
using Proiect_final.Data;
using Proiect_final.Models.Adress;
using Proiect_final.Repositories.GenericRepository;

namespace Proiect_final.Repositories.AdressRepository
{
    public class AdressRepository : GenericRepository<Adress>, IAdressRepository
    {
        public AdressRepository(ApiDbContext context) : base(context)
        {
        }
        //get adress by driver id
        public async Task<Adress> GetAdressByDriverId(Guid driverId)
        {
            return await _table
                .FirstOrDefaultAsync(a => a.DriverId == driverId);
        }
    }
}
