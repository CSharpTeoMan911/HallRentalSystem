using HallRentalSystem.Classes.DTO;
using HallRentalSystem.Classes;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class Authentication_Controller : Controller, CRUD_Strategy<Customers, string, Customers, string, ActionResult<string>>
    {
        [HttpDelete("delete-account")]
        public Task<ActionResult<string>> Delete([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string>>("OK Delete");
        }

        [HttpGet("get-account")]
        public Task<ActionResult<string>> Get([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string>>(Content("OK Get"));
        }

        [HttpPost("insert-account")]
        public Task<ActionResult<string>> Insert([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string>>("OK Insert");
        }

        [HttpPut("update-account")]
        public Task<ActionResult<string>> Update([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string>>("OK Update");
        }
    }
}
