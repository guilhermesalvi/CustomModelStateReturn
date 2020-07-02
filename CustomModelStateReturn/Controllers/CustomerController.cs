using CustomModelStateReturn.Controllers.Responses;
using CustomModelStateReturn.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelStateReturn.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpPost("")]
        public IActionResult Register(Customer customer)
        {
            return Ok(new ResponseBase
            {
                Succeeded = true
            });
        }
    }
}
