using AutoMapper;
using Proiect_final.Models.Adress;
using Proiect_final.Models.Adress.DTO;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Bus.DTO;
using Proiect_final.Models.Defection;
using Proiect_final.Models.Defection.DTO;
using Proiect_final.Models.Driver;
using Proiect_final.Models.Driver.DTO;
using Proiect_final.Models.RepairHistory;
using Proiect_final.Models.RepairHistory.DTO;

namespace Proiect_final.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Bus, BusResponseDto>()
                .ForMember(dest => dest.DriversNames, opt => opt.MapFrom(src => src.Drivers.Select(driver => driver.Name)))
                .ForMember(dest => dest.DefectionsNames, opt => opt.MapFrom(src => src.RepairHistories.Select(repairHistory => repairHistory.Defection.DefectionName)));
                
            CreateMap<BusRequestDto, Bus>();

            CreateMap<Driver, DriverResponseDto>()
                .ForMember(dest => dest.BusNumber, opt => opt.MapFrom(src => src.Bus.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Adress.City));
            CreateMap<DriverRequestDto, Driver>();

            CreateMap<Adress, AdressResponseDto>();
            CreateMap<AdressRequestDto, Adress>();

            CreateMap<Defection, DefectionResponseDto>();
            CreateMap<DefectionRequestDto, Defection>();

            CreateMap<RepairHistory, RepairHistoryResponseDto>();
            CreateMap<RepairHistoryRequestDto, RepairHistory>();
        }

    }
}
