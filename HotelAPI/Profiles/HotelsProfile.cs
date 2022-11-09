using AutoMapper;

namespace HotelAPI.Profiles
{
    public class HotelsProfile : Profile
    {
        public HotelsProfile()
        {
            CreateMap<Models.Domain.Hotel, Models.DTO.Hotel>()
                .ReverseMap();

            CreateMap<Models.Domain.Review, Models.DTO.Review>()
                .ReverseMap();
        }
    }
}
