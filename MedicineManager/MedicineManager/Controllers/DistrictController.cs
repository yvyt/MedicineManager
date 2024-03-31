using MedicineManager.Data;
using MedicineManager.Models.CustomerRequest;
using MedicineManager.Services.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DistrictService _services;

        public DistrictController(DistrictService services)
        {
            _services = services;
        }
        [HttpPost("createDistrict")]
        public async Task<IActionResult> createDistrict(DistrictRequest district)
        {
            var result = await _services.CreateOrUpdateDistrict(district);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> getAllDistrict()
        {
            var result = await _services.GetAll();
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{district_id}")]
        public async Task<IActionResult> getById(int district_id)
        {
            var result = await _services.getDistrictById(district_id);
            if(result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByCity/{city_id}")]
        public async Task<IActionResult> getDistrictByCityId(int city_id)
        {
            var result = await _services.GetDistrictByCityId(city_id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateDistrict(DistrictRequest district)
        {
            var result = await _services.CreateOrUpdateDistrict(district);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("deleteCity/{id}")]
        public async Task<IActionResult> DeleteUpdate(int id)
        {
            var result = await _services.DeleteDistrict(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
