using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Bus.DTO;
using Proiect_final.Services.BusService;

namespace Proiect_final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly IMapper _mapper;

        public BusController(IBusService busService, IMapper mapper)
        {
            _busService = busService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusResponseDto>>> GetAllBuses()
        {
            var buses = await _busService.GetAllBuses();
            var busesDto = _mapper.Map<IEnumerable<BusResponseDto>>(buses);
            return Ok(busesDto);
        }

        [HttpPost]
        public async Task<ActionResult<BusResponseDto>> CreateBus(BusRequestDto busRequestDto)
        {
            var bus = _mapper.Map<Bus>(busRequestDto);
            await _busService.CreateBus(bus);
            var busResponseDto = _mapper.Map<BusResponseDto>(bus);
            return Ok(busResponseDto);
        }

        //get bus by id
        [HttpGet("{id}")]
        public async Task<ActionResult<BusResponseDto>> GetBusById(Guid id)
        {
            var bus = await _busService.GetBusById(id);
            var busResponseDto = _mapper.Map<BusResponseDto>(bus);
            return Ok(busResponseDto);
        }

        //delet bus
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBus(Guid id)
        {
            var deletedBus = await _busService.GetBusById(id);
            if (deletedBus == null)
            {
                return NotFound($"Bus with ID {id} not found");
            }
            await _busService.DeleteBus(deletedBus);
            return NoContent();
        }

        // get bus by string number
        [HttpGet("number/{number}")]
        public async Task<ActionResult<BusResponseDto>> GetBusByNumber(string number)
        {
            var bus = await _busService.GetBusByNumber(number);

            if (bus == null)
            {
                return NotFound(); 
            }

            var busResponseDto = _mapper.Map<BusResponseDto>(bus);
            return Ok(busResponseDto);
        }

        //update bus
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BusResponseDto>> UpdateBus(Guid id, BusRequestDto busRequestDto)
        {
            var bus = await _busService.GetBusById(id);
            if (bus == null)
            {
                return NotFound($"Bus with ID {id} not found");
            }

            _mapper.Map(busRequestDto, bus);
            await _busService.UpdateBus(bus);
            var busResponseDto = _mapper.Map<BusResponseDto>(bus);
            return Ok(busResponseDto);
        }

        //get buses number of buses group by capacity
        [HttpGet("capacity")]
        public async Task<ActionResult<IEnumerable<BusResponseDto>>> GetBusesGroupByCapacity()
        {
            var buses = await _busService.GetAllBuses();
            var busesDto = _mapper.Map<IEnumerable<BusResponseDto>>(buses);
            var busesGroupByCapacity = busesDto.GroupBy(b => b.Capacity);
            return Ok(busesGroupByCapacity);
        }



    }

        
    
            
}
