using MedicineManager.Data;
using MedicineManager.Models;
using MedicineManager.Models.CustomerRequest;
using MedicineManager.Services.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {

            if(ModelState.IsValid)
            {
                var result = await _userServices.CreateOrUpdateUser(user);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Something is not valid...");

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userServices.GetAll();
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userServices.GetById(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserRequest u)
        {
            if(ModelState.IsValid)
            {
                var result = await _userServices.CreateOrUpdateUser(u);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Something is not valid...");
        }
        [HttpPut("InActiveUser")]
        public async Task<IActionResult> InActive(int id)
        {
            var result = await _userServices.InActive(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userServices.DeleteUser(id);
            if (result.isSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
