using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proiect_final.Models.RepairHistory;
using Proiect_final.Models.RepairHistory.DTO;
using Proiect_final.Services.RepairHistoryService;

namespace Proiect_final.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepairHistoryController : ControllerBase
    {
        private readonly IRepairHistoryService _repairHistoryService;
        private readonly IMapper _mapper;
        public RepairHistoryController(IRepairHistoryService repairHistoryService, IMapper mapper)
        {
            _repairHistoryService = repairHistoryService;
            _mapper = mapper;
        }

        //get all repair histories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairHistoryResponseDto>>> GetAllRepairHistories()
        {
            var repairHistories = await _repairHistoryService.GetAllRepairHistories();
            var repairHistoriesDto = _mapper.Map<IEnumerable<RepairHistoryResponseDto>>(repairHistories);
            return Ok(repairHistoriesDto);
        }

        //create repair history
        [HttpPost]
        public async Task<ActionResult<RepairHistoryResponseDto>> CreateRepairHistory(RepairHistoryRequestDto repairHistoryRequestDto)
        {
            var repairHistory = _mapper.Map<RepairHistory>(repairHistoryRequestDto);
            await _repairHistoryService.CreateRepairHistory(repairHistory);
            var repairHistoryResponseDto = _mapper.Map<RepairHistoryResponseDto>(repairHistory);
            return Ok(repairHistoryResponseDto);
        }
    }
}
