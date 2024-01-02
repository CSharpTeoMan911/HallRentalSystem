using HallRentalSystem.Classes;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class Authentication_Controller : Controller, CRUD_API_Strategy<Customers, TestObject, Customers, string>
    {
        [HttpDelete("delete-account")]
        public Task<ActionResult<string?>> Delete([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }

        [HttpGet("get-account")]
        public Task<ActionResult<string?>> Get([FromQuery] TestObject? data)
        {
            Console.WriteLine("Result:\n" + Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented));
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }

        [HttpPost("insert-account")]
        public Task<ActionResult<string?>> Insert([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }

        [HttpPut("update-account")]
        public Task<ActionResult<string?>> Update([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }
    }
}
