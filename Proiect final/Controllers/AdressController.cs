using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_final.Models.Adress;
using Proiect_final.Models.Adress.DTO;
using Proiect_final.Services.AdressService;

namespace Proiect_final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;
        private readonly IMapper _mapper;

        public AdressController(IAdressService adressService, IMapper mapper)
        {
            _adressService = adressService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdressResponseDto>>> GetAllAdresses()
        {
            var adresses = await _adressService.GetAllAdresses();
            var adressesDto = _mapper.Map<IEnumerable<AdressResponseDto>>(adresses);
            return Ok(adressesDto);
        }

        [HttpPost, Authorize(Roles = "User")]
        public async Task<ActionResult<AdressResponseDto>> CreateAdress(AdressRequestDto adressRequestDto)
        {
            var adress = _mapper.Map<Adress>(adressRequestDto);
            await _adressService.CreateAdress(adress);
            var adressResponseDto = _mapper.Map<AdressResponseDto>(adress);
            return Ok(adressResponseDto);
        }

        //find adresses for a driver by driver id
        [HttpGet("DriverAdress/{id:guid}")]
        public async Task<ActionResult<AdressResponseDto>> GetAdressByDriverId(Guid id)
        {
            var adress = await _adressService.GetAdressByDriverId(id);
            var adressResponseDto = _mapper.Map<AdressResponseDto>(adress);
            return Ok(adressResponseDto);
        }

        //update adress
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AdressResponseDto>> UpdateAdress(Guid id, AdressRequestDto adressRequestDto)
        {
            var adress = await _adressService.GetAdressById(id);
            if (adress == null)
            {
                return NotFound($"Adress with ID {id} not found");
            }
            _mapper.Map(adressRequestDto, adress);
            await _adressService.UpdateAdress(adress);
            var adressResponseDto = _mapper.Map<AdressResponseDto>(adress);
            return Ok(adressResponseDto);

        }

        //delete adress
        [HttpDelete("{id:guid}"), Authorize(Roles = "User")]
        public async Task<ActionResult> DeleteAdress(Guid id)
        {
            var deletedAdress = await _adressService.GetAdressById(id);
            if (deletedAdress == null)
            {
                return NotFound($"Adress with ID {id} not found");
            }
            await _adressService.DeleteAdress(deletedAdress);
            return NoContent();
        }
    }
}
