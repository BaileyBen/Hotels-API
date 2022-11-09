using AutoMapper;

namespace HotelAPI.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
            .ReverseMap();
        }
    }
}
