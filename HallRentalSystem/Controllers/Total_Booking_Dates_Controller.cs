using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [Route("/total-booking-dates")]
    public class Total_Booking_Dates_Controller : Controller, CRUD_API_Strategy<TotalBookingDatesParameters, string, TotalBookingDatesParameters, string>
    {
        [HttpDelete("delete")]
        public async Task<ActionResult<string?>> Delete([FromQuery] string? data)
        {
            string? result = await Shared_Data.total_bookings.Delete<string>(data);
            return (ActionResult<string?>)result;
        }

        [HttpGet("get")]
        public async Task<ActionResult<string?>> Get([FromQuery] string? data)
        {
            string? result = await Shared_Data.total_bookings.Get<string>(data);
            return (ActionResult<string?>)result;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<string?>> Insert([FromQuery] TotalBookingDatesParameters? data)
        {
            string? result = await Shared_Data.total_bookings.Insert<string>(data);
            return (ActionResult<string?>)result;
        }

        [HttpPut("update")]
        public async Task<ActionResult<string?>> Update([FromQuery] TotalBookingDatesParameters? data)
        {
            string? result = await Shared_Data.total_bookings.Update<string>(data);
            return (ActionResult<string?>)result;
        }
    }
}
