using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/booking")]
    public class Booking_Controller : Controller, CRUD_API_Strategy<string, string, string, string>
    {
        [HttpDelete("delete-booking")]
        public Task<ActionResult<string?>> Delete(string? data)
        {
            throw new NotImplementedException();
        }

        [HttpGet("get-booking")]
        public Task<ActionResult<string?>> Get(string? data)
        {
            throw new NotImplementedException();
        }

        [HttpPost("insert-booking")]
        public Task<ActionResult<string?>> Insert(string? data)
        {
            return Task.FromResult<ActionResult<string>>(data);
        }

        [HttpPut("update-booking")]
        public Task<ActionResult<string?>> Update(string? data)
        {
            throw new NotImplementedException();
        }
    }
}
