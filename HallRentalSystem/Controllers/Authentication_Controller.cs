using HallRentalSystem.Classes;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class Authentication_Controller : Controller, CRUD_API_Strategy<Customers, string, Customers, string>
    {
        [HttpDelete("delete-account")]
        public Task<ActionResult<string>> Delete([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string>>(Content("OK Get"));
        }

        [HttpGet("get-account")]
        public Task<ActionResult<string>> Get([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string>>(Content("OK Get"));
        }

        [HttpPost("insert-account")]
        public Task<ActionResult<string>> Insert([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string>>(Content("OK Get"));
        }

        [HttpPut("update-account")]
        public Task<ActionResult<string>> Update([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string>>(Content("OK Get"));
        }
    }
}
