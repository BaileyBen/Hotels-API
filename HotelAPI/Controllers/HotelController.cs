using AutoMapper;
using HotelAPI.Models.Domain;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var hotelsDTO = _mapper.Map<List<Models.DTO.Hotel>>(hotels);

            return Ok(hotelsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetHotelAsync")]
        public async Task<IActionResult> GetHotelAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);

            var hotelDTO = _mapper.Map<Models.DTO.Hotel>(hotel);

            return Ok(hotelDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddHotelAsync(Hotel hotel)
        {
            hotel = new Models.Domain.Hotel();

            var hotelDomain = await _hotelRepository.AddHotelAsync(hotel);

            var houseDTO = _mapper.Map<Models.DTO.AddHotelRequest>(hotelDomain);

            return Ok(houseDTO);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotelAsync(Guid id, Hotel hotel)
        {
            hotel = new Models.Domain.Hotel();

            var hotelDomain = await _hotelRepository.UpdateHotelAsync(id, hotel);

            if (hotelDomain == null)
            {
                return NotFound();
            }
            else
            {

                var hotelDTO = _mapper.Map<Models.DTO.UpdateHotelRequest>(hotelDomain);

                return CreatedAtAction(nameof(GetHotelAsync), hotelDTO);
            }
            
        }
    }
}
