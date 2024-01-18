using HallRentalSystem.Classes;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;


namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class Authentication_Controller : Controller, CRUD_API_Strategy<Customer_ID_Value, Customer_ID_Value, Customers, string>
    {
        [HttpDelete("delete-account")]
        public Task<ActionResult<string?>> Delete([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }

        [HttpGet("get-account")]
        public async Task<ActionResult<string?>> Get([FromQuery] Customer_ID_Value? data)
        {
            string? result = "Internal server error";

            if (data != null)
            {
                result = await Shared_Data.authentication.Get<string>(data);
            }

            if (result == null)
                result = "false";

            return (ActionResult<string?>)Content(result);
        }

        [HttpPost("insert-account")]
        public async Task<ActionResult<string?>> Insert([FromQuery] Customer_ID_Value? data)
        {
            string? result = "Internal server error";

            if (data?.Email != null)
            {
                result = await Shared_Data.authentication.Insert<string>(data);
            }

            if (result == null)
                result = "false";

            return (ActionResult<string?>)Content(result);
        }

        [HttpPut("update-account")]
        public Task<ActionResult<string?>> Update([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }
    }
}
