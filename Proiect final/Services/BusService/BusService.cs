using Microsoft.AspNetCore.Mvc;
using Proiect_final.Data.UnitOfWork;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Driver;
using Proiect_final.Repositories.BusRepository;
using Proiect_final.Specification;

namespace Proiect_final.Services.BusService
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BusService(IBusRepository busRepository, IUnitOfWork unitOfWork)
        {
            _busRepository = busRepository;
            _unitOfWork = unitOfWork;
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
            await _unitOfWork.SaveAsync();
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
            await _unitOfWork.SaveAsync();
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
            await _unitOfWork.SaveAsync();
        }

        //get buses by capacity
        public async Task<List<string>> GetBusesNumbersByCapacity(int capacity)
        {
            return await _busRepository.GetBusesNumbersByCapacity(capacity);
        }

        //get buses by specification
        public ActionResult<List<Bus>> GetBusesSpecification(MilitariBuses specification)
        {
            return _busRepository.GetBusesBySpecification(specification);
        }


    }
}
