using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HouseAPI.Domain.Models;
using HouseAPI.Domain.Services;
using HouseAPI.Extensions;
using HouseAPI.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HouseAPI.Controllers
{
    [Route("/api/[controller]")]
    public class ResidentsController : Controller
    {
        private readonly IResidentService _residentService;
        private readonly IMapper _mapper;

        public ResidentsController(IResidentService residentService, IMapper mapper)
        {
            _residentService = residentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ResidentResource>> ListAsync()
        {
            var residents = await _residentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Resident>, IEnumerable<ResidentResource>>(residents);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveResidentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var resident = _mapper.Map<SaveResidentResource, Resident>(resource);
            var result = await _residentService.SaveAsync(resident);

            if (!result.Success)
                return BadRequest(result.Message);

            var residentResource = _mapper.Map<Resident, ResidentResource>(result.Resident);
            return Ok(residentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveResidentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var resident = _mapper.Map<SaveResidentResource, Resident>(resource);
            var result = await _residentService.UpdateAsync(id, resident);

            if (!result.Success)
                return BadRequest(result.Message);

            var residentResource = _mapper.Map<Resident, ResidentResource>(result.Resident);
            return Ok(residentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _residentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var residentResource = _mapper.Map<Resident, ResidentResource>(result.Resident);
            return Ok(residentResource);
        }
    }
}
