using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/log-out")]
    public class Logout_Controller : Controller, CRUD_API_Strategy<string, string, string, FirebaseKey>
    {
        [HttpDelete("user-log-out")]
        public async Task<ActionResult<string?>> Delete([FromQuery] FirebaseKey? data)
        {
            string? result = "Internal server error";

            result = await Shared_Data.log_in_session.Delete<string>(data);

            if (result == null)
                result = "Internal server error";

            return (ActionResult<string?>)Content(result);
        }

        [HttpGet("get")]
        public Task<ActionResult<string?>> Get(string? data)
        {
            ///////////////////////////////
            // !!!! NOT IMPLEMENTED !!!! //
            ///////////////////////////////
            return Task.FromResult((ActionResult<string?>)Content("!!! NOT IMPLEMENTED !!!"));
        }

        [HttpPost("insert")]
        public Task<ActionResult<string?>> Insert(string? data)
        {
            ////////////////////////////////
            // !!!! NOT IMPLEMENTED !!!! ///
            ////////////////////////////////
            return Task.FromResult((ActionResult<string?>)Content("!!! NOT IMPLEMENTED !!!"));
        }

        [HttpPut("update")]
        public Task<ActionResult<string?>> Update(string? data)
        {
            ///////////////////////////////
            // !!!! NOT IMPLEMENTED !!!! //
            ///////////////////////////////
            return Task.FromResult((ActionResult<string?>)Content("!!! NOT IMPLEMENTED !!!"));
        }
    }
}
