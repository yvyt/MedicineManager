using MedicineManager.Models.CustomerRequest;
using MedicineManager.Services.Customer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly WardServices _services;

        public WardController(WardServices services)
        {
            _services = services;
        }
        [HttpPost("createWard")]
        public async Task<IActionResult> createWard(WardRequest ward)
        {
            var result = await _services.CreateOrUpdate(ward);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var result = await _services.GetAll();
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{ward_id}")]
        public async Task<IActionResult> getWardById(int ward_id)
        {
            var result = await _services.GetById(ward_id);
            if(result.isSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getByDistrict/{district_id}")]
        public async Task<IActionResult> getByDistrict(int district_id)
        {
            var result = await _services.getByDistrict(district_id);
            if (result.isSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> updateWard(WardRequest ward)
        {
            var result = await _services.CreateOrUpdate(ward);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("deleteWard/{id}")]
        public async Task<IActionResult> deleteWard(int id)
        {
            var result = await _services.DeleteWard(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
