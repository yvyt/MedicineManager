using MedicineManager.Models.CustomerRequest;
using MedicineManager.Services.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityServices _services;

        public CityController(CityServices services)
        {
            _services = services;
        }
        [HttpPost("createCity")]
        public async Task<IActionResult> createCity(CityRequest city)
        {
            var result = await _services.CreateOrUpdateCity(city);
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
        [HttpGet("{city_Id}")]
        public async Task<IActionResult> getById(int city_Id)
        {
            var result = await _services.GetById(city_Id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> updateCity(CityRequest city)
        {
            var result = await _services.CreateOrUpdateCity(city);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("deleteCity/{id}")]
        public async Task<IActionResult> deleteCity(int id)
        {
            var result = await _services.DeleteCity(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
