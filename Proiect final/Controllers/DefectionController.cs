using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proiect_final.Models.Defection;
using Proiect_final.Models.Defection.DTO;
using Proiect_final.Services.DefectionService;

namespace Proiect_final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefectionController : ControllerBase
    {
        private readonly IDefectionService _defectionService;
        private readonly IMapper _mapper;
        public DefectionController(IDefectionService defectionService, IMapper mapper)
        {
            _defectionService = defectionService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDefections()
        { 
            var defections = await _defectionService.GetAllDefections();
            var defectionsDto = _mapper.Map<IEnumerable<DefectionResponseDto>>(defections);
            return Ok(defectionsDto);
        }


        [HttpPost]
        public async Task<ActionResult<DefectionResponseDto>> CreateDefection(DefectionRequestDto defectionRequestDto)
        {
            var defection = _mapper.Map<Defection>(defectionRequestDto);
            await _defectionService.CreateDefection(defection);
            var defectionResponseDto = _mapper.Map<DefectionResponseDto>(defection);
            return Ok(defectionResponseDto);
        }

        //get defection by id
        [HttpGet("{id}")]
        public async Task<ActionResult<DefectionResponseDto>> GetDefectionById(Guid id)
        {
            var defection = await _defectionService.GetDefectionById(id);
            var defectionResponseDto = _mapper.Map<DefectionResponseDto>(defection);
            return Ok(defectionResponseDto);
        }

        //update defection
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<DefectionResponseDto>> UpdateDefection(Guid id, DefectionRequestDto defectionRequestDto)
        {
            var defection = await _defectionService.GetDefectionById(id);
            if (defection == null)
            {
                return NotFound($"Defection with ID {id} not found");
            }
            _mapper.Map(defectionRequestDto, defection);
            await _defectionService.UpdateDefection(defection);
            var defectionResponseDto = _mapper.Map<DefectionResponseDto>(defection);
            return Ok(defectionResponseDto);
        }

        //delete defection
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteDefection(Guid id)
        {
            var defection = await _defectionService.GetDefectionById(id);
            if (defection == null)
            {
                return NotFound($"Defection with ID {id} not found");
            }
            await _defectionService.DeleteDefection(defection);
            return Ok();
        }
        
    }
}
