using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/log-out")]
    public class Logout_Controller : Controller, CRUD_API_Strategy<string, string, string, string>
    {
        [HttpDelete("user-log-out")]
        public async Task<ActionResult<string?>> Delete([FromQuery]string? data)
        {
            string? result = "Internal server error";

            result = await Shared_Data.log_in_session.Delete<string>(data);

            if (result == null)
                result = "Internal server error";

            return (ActionResult<string?>)Content(result);
        }

        public Task<ActionResult<string?>> Get(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<string?>> Insert(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<string?>> Update(string? data)
        {
            throw new NotImplementedException();
        }
    }
}
