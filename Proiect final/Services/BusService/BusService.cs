using Proiect_final.Models.Bus;
using Proiect_final.Models.Driver;
using Proiect_final.Repositories.BusRepository;

namespace Proiect_final.Services.BusService
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        // get all buses
        public async Task<IEnumerable<Bus>> GetAllBuses()
        {
            return await _busRepository.GetAllBusesAsync();
        }

        // create bus
        public async Task CreateBus(Bus bus)
        {
            await _busRepository.CreateAsync(bus);
            await _busRepository.SaveAsync();
        }

        // get bus by id
        public async Task<Bus> GetBusById(Guid id)
        {
            return await _busRepository.FindByIdAsync(id);
        }

        //delete bus
        public async Task DeleteBus(Bus bus)
        {
            _busRepository.Delete(bus);
            await _busRepository.SaveAsync();
        }

        //get bus by number
        public async Task<Bus> GetBusByNumber(string number)
        {
            return await _busRepository.FindSingleOrDefaultAsync(b => b.Number == number);
        }

        //update bus
        public async Task UpdateBus(Bus bus)
        {
            _busRepository.Update(bus);
            await _busRepository.SaveAsync();
        }

        //get buses by capacity
        public async Task<List<string>> GetBusesNumbersByCapacity(int capacity)
        {
            return await _busRepository.GetBusesNumbersByCapacity(capacity);
        }




    }
}
