using Proiect_final.Models.Bus;

namespace Proiect_final.Services.BusService
{
    public interface IBusService
    {
        Task<IEnumerable<Bus>> GetAllBuses();

        Task CreateBus(Bus bus);

        //get bus by id
        Task<Bus> GetBusById(Guid id);

        //delete bus
        Task DeleteBus(Bus bus);
    }
}
