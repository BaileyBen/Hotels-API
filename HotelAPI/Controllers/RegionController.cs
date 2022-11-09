using AutoMapper;
using HotelAPI.Models.Domain;
using HotelAPI.Models.DTO;
using HotelAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await _regionRepository.GetRegionsASync();

            var regionsDTO = _mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetRegionIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Country = addRegionRequest.Country,
                State = addRegionRequest.State,
                City = addRegionRequest.City,
                Postcode = addRegionRequest.Postcode
            };

            var response = await _regionRepository.AddRegionAsync(region);

            var regionsDTO = _mapper.Map<Models.DTO.Region>(response);

            return CreatedAtAction(nameof(GetAllRegionsAsync), new { id = regionsDTO.Id }, regionsDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = _regionRepository.DeleteRegionAsync(id);

            if ( region == null)
            {
                return NotFound();
            }

            var regionsDTO = _mapper.Map<Models.DTO.Region>(region);

            return Ok(regionsDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(
            [FromRoute] Guid id, [FromBody] Models.DTO.AddRegionRequest updateRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Country = updateRegionRequest.Country,
                State = updateRegionRequest.State,
                City = updateRegionRequest.City,
                Postcode = updateRegionRequest.Postcode
            };

            region = await _regionRepository.UpdateRegionAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = _mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }
    }
}
