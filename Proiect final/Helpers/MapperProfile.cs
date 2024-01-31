using AutoMapper;
using Proiect_final.Models.Adress;
using Proiect_final.Models.Adress.DTO;
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
            CreateMap<Bus, BusResponseDto>()
                .ForMember(dest => dest.DriversNames, opt => opt.MapFrom(src => src.Drivers.Select(driver => driver.Name)));
            CreateMap<BusRequestDto, Bus>();

            CreateMap<Driver, DriverResponseDto>()
                .ForMember(dest => dest.BusNumber, opt => opt.MapFrom(src => src.Bus.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Adress.City));
            CreateMap<DriverRequestDto, Driver>();

            CreateMap<Adress, AdressResponseDto>();
            CreateMap<AdressRequestDto, Adress>();
        }

    }
}
