using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HouseAPI.Domain.Models;
using HouseAPI.Domain.Services;
using HouseAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using HouseAPI.Extensions;

namespace HouseAPI.Controllers
{
    [Route("api/[controller]")]
    public class HousesController : Controller
    {
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public HousesController(IHouseService houseService, IMapper mapper)
        {
            _houseService = houseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HouseResource>> GetAllAsync()
        {
            var houses = await _houseService.ListAsync(); 
            var resources = _mapper.Map<IEnumerable<House>, IEnumerable<HouseResource>>(houses);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHouseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var house = _mapper.Map<SaveHouseResource, House>(resource);
            var result = await _houseService.SaveAsync(house);

            if (!result.Success)
                return BadRequest(result.Message);

            var houseResource = _mapper.Map<House, HouseResource>(result.House);
            return Ok(houseResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHouseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var house = _mapper.Map<SaveHouseResource, House>(resource);
            var result = await _houseService.UpdateAsync(id, house);

            if (!result.Success)
                return BadRequest(result.Message);

            var houseResource = _mapper.Map<House, HouseResource>(result.House);
            return Ok(houseResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) 
        { 
            var result = await _houseService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var houseResource = _mapper.Map<House, HouseResource>(result.House);
            return Ok(houseResource);
        }
    }
}
