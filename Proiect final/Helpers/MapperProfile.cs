using AutoMapper;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Bus.DTO;
using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;

namespace Proiect_final.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Bus, BusResponseDto>();
            CreateMap<BusRequestDto, Bus>();

            CreateMap<Driver, DriverResponseDto>();
            CreateMap<DriverRequestDto, Driver>();
        }

    }
}
