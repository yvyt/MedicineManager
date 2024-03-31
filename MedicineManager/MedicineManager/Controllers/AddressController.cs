using MedicineManager.Data;
using MedicineManager.Models.CustomerRequest;
using MedicineManager.Services.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressServices _service;

        public AddressController(AddressServices service)
        {
            _service = service;
        }

        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateAddress(AddressRequest address)
        {
            var result = await _service.CreateOrUpdateAddress(address);
            if(result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var result = await _service.GetByUser(userId);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(AddressRequest a)
        {
            var result = await _service.CreateOrUpdateAddress(a);
            if(result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await _service.DeleteAddress(id);
            if(result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
