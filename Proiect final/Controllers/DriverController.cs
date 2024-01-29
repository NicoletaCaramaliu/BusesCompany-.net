using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proiect_final.Data;
using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverResponseDto>>> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDrivers();
            var driversDto = _mapper.Map<IEnumerable<DriverResponseDto>>(drivers);
            return Ok(driversDto);
        }

        [HttpPost]
        public async Task<ActionResult<DriverResponseDto>> CreateDriver(DriverRequestDto driverRequestDto)
        {
            var driver = _mapper.Map<Driver>(driverRequestDto);
            await _driverService.CreateDriver(driver);
            var driverResponseDto = _mapper.Map<DriverResponseDto>(driver);
            return Ok(driverResponseDto);
        }
    }
}
