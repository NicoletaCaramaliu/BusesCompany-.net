using Microsoft.AspNetCore.Mvc;
using Proiect_final.Models.Bus;
using Proiect_final.Specification;

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

        //get bus by number
        Task<Bus> GetBusByNumber(string number);

        //update bus
        Task UpdateBus(Bus bus);

        //get buses by capacity
        Task<List<string>> GetBusesNumbersByCapacity(int capacity);
        ActionResult<List<Bus>> GetBusesSpecification(MilitariBuses specification);
    }
}
