using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking;
using Microsoft.AspNetCore.Mvc;
using HallRentalSystem.Classes;
using HallRentalSystem.Classes.API_Parameters;

namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/booking")]
    public class Booking_Controller : Controller, CRUD_API_Strategy<Booking_Parameters, string, string, string>
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
        public async Task<ActionResult<string?>> Insert([FromQuery]Booking_Parameters? data)
        {
            string? result = await Shared_Data.bookings.Insert<string>(data);
            return result;
        }

        [HttpPut("update-booking")]
        public Task<ActionResult<string?>> Update(string? data)
        {
            throw new NotImplementedException();
        }
    }
}
