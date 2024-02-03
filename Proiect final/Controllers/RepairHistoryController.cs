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

        //get repair history by id
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairHistoryResponseDto>> GetRepairHistoryById(Guid id)
        {
            var repairHistory = await _repairHistoryService.GetRepairHistoryById(id);
            var repairHistoryResponseDto = _mapper.Map<RepairHistoryResponseDto>(repairHistory);
            return Ok(repairHistoryResponseDto);
        }

        //update repair history
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<RepairHistoryResponseDto>> UpdateRepairHistory(Guid id, RepairHistoryRequestDto repairHistoryRequestDto)
        {
            var repairHistory = await _repairHistoryService.GetRepairHistoryById(id);
            if (repairHistory == null)
            {
                return NotFound($"Repair history with ID {id} not found");
            }
            _mapper.Map(repairHistoryRequestDto, repairHistory);
            await _repairHistoryService.UpdateRepairHistory(repairHistory);
            var repairHistoryResponseDto = _mapper.Map<RepairHistoryResponseDto>(repairHistory);
            return Ok(repairHistoryResponseDto);
        }

        //delete repair history
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteRepairHistory(Guid id)
        {
            var deletedRepairHistory = await _repairHistoryService.GetRepairHistoryById(id);
            if (deletedRepairHistory == null)
            {
                return NotFound($"Repair history with ID {id} not found");
            }
            await _repairHistoryService.DeleteRepairHistory(deletedRepairHistory);
            return NoContent();
        }
    }
}
