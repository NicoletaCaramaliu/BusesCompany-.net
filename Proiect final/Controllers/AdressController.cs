using AutoMapper;
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

        [HttpPost]
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
    }
}
