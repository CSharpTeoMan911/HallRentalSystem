using HallRentalSystem.Classes;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;


namespace HallRentalSystem.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class Authentication_Controller : Controller, CRUD_API_Strategy<Customer_ID_Value, Customer_ID_Value, Customers, string>
    {
        // DELETE AN USER ACCOUNT FROM THE DATABASE
        [HttpDelete("delete-account")]
        public Task<ActionResult<string?>> Delete([FromQuery] string? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }

        // GET AND VALIDATE AN USER ACCOUNT IN ORDER FOR THE USER TO LOG IN
        [HttpGet("get-account")]
        public async Task<ActionResult<string?>> Get([FromQuery] Customer_ID_Value? data)
        {
            string? result = null;

            // INTITIATE THE USER LOG IN PROCEDURE
            result = await Shared_Data.authentication.Get<string>(data);

            if (result == null)
                result = "Internal server error";

            return (ActionResult<string?>)Content(result);
        }

        // INSERT AN USER ACCOUNT IN THE DATABASE IN ORDER FOR THE USER TO REGISTER
        [HttpPost("insert-account")]
        public async Task<ActionResult<string?>> Insert([FromQuery] Customer_ID_Value? data)
        {
            string? result = null;

            // INITIATE THE USER REGISTER PROCEDURE
            result = await Shared_Data.authentication.Insert<string>(data);

            if (result == null)
                result = "Internal server error";

            return (ActionResult<string?>)Content(result);
        }

        // UPDATE THE INFORMATION OF AN USER ACCOUNT
        [HttpPut("update-account")]
        public Task<ActionResult<string?>> Update([FromQuery] Customers? data)
        {
            return Task.FromResult<ActionResult<string?>>(Content("OK Get"));
        }
    }
}
