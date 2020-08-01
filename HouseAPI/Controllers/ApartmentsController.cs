using System.Collections.Generic;
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
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;

        public ApartmentsController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApartmentResource>> ListAsync()
        {
            var apartments = await _apartmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Apartment>, IEnumerable<ApartmentResource>>(apartments);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApartmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var apartment = _mapper.Map<SaveApartmentResource, Apartment>(resource);
            var result = await _apartmentService.SaveAsync(apartment);

            if (!result.Success)
                return BadRequest(result.Message);

            var apartmentResource = _mapper.Map<Apartment, ApartmentResource>(result.Apartment);
            return Ok(apartmentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveApartmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var apartment = _mapper.Map<SaveApartmentResource, Apartment>(resource);
            var result = await _apartmentService.UpdateAsync(id, apartment);

            if (!result.Success)
                return BadRequest(result.Message);

            var apartmentResource = _mapper.Map<Apartment, ApartmentResource>(result.Apartment);
            return Ok(apartmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _apartmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var apartmentResource = _mapper.Map<Apartment, ApartmentResource>(result.Apartment);
            return Ok(apartmentResource);
        }
    }
}
