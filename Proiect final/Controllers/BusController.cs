using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        [HttpDelete("{id}")]
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


    }

        
    
            
}
