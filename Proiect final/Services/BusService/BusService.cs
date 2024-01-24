﻿using Proiect_final.Models.Bus;
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
            return await _busRepository.GetAllAsync();
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
    }
}