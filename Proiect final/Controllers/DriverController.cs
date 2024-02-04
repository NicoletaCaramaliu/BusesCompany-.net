using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_final.Data;
using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;
using Proiect_final.Repositories.BusRepository;
using Proiect_final.Services.DriverService;

namespace Proiect_final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ApiDbContext _ApiDbContext;
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverService, IMapper mapper, ApiDbContext _ApiDbContext)
        {
            _driverService = driverService;
            _mapper = mapper;
            _ApiDbContext = _ApiDbContext;
        }

        [HttpGet, Authorize(Roles ="Admin, User")]
        public async Task<ActionResult<IEnumerable<DriverResponseDto>>> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDrivers();
            var driversDto = _mapper.Map<IEnumerable<DriverResponseDto>>(drivers);
            return Ok(driversDto);
        }

        [HttpPost("{busId:guid}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<DriverResponseDto>> CreateDriver(DriverRequestDto driverRequestDto, Guid busId)
        {
            var driver = _mapper.Map<Driver>(driverRequestDto);
            await _driverService.CreateDriver(driver, busId);
            var driverResponseDto = _mapper.Map<DriverResponseDto>(driver);
            return Ok(driverResponseDto);
        }


        //get driver by id
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverResponseDto>> GetDriverById(Guid id)
        {
            var driver = await _driverService.GetDriverById(id);
            var driverResponseDto = _mapper.Map<DriverResponseDto>(driver);
            return Ok(driverResponseDto);
        }
        
        //update driver

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DriverResponseDto>> UpdateDriver(Guid id, DriverRequestDto driverRequestDto)
        {
            var driver = await _driverService.GetDriverById(id);
            if (driver == null)
            {
                return NotFound($"Driver with ID {id} not found");
            }
            _mapper.Map(driverRequestDto, driver);
            await _driverService.UpdateDriver(driver);
            var driverResponseDto = _mapper.Map<DriverResponseDto>(driver);
            return Ok(driverResponseDto);
        }

        //delete driver
        [HttpDelete("{id:guid}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDriver(Guid id)
        {
            var deletedDriver = await _driverService.GetDriverById(id);
            if (deletedDriver == null)
            {
                return NotFound($"Driver with ID {id} not found");
            }
            await _driverService.DeleteDriver(deletedDriver);
            return NoContent();
        }

        //get drivers names ordered by age desc
        [HttpGet("ageDesc")]
        public async Task<ActionResult<List<string>>> GetDriversNamesOrderedByAgeDesc()
        {
            var driversNames = await _driverService.GetDriversNamesOrderedByAgeDesc();
            return Ok(driversNames);
        }

        //get defection names by driver id
        [HttpGet("DefectionNames/{id:guid}")]
        public async Task<ActionResult<List<string>>> GetDefectionNamesByDriver(Guid id)
        {
            var defectionNames = await _driverService.GetDefectionNames(id);
            return Ok(defectionNames);
        }
    }
}
