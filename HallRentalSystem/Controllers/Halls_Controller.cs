using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database.Query;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HallRentalSystem.Controllers
{
    [Firebase_Database]
    [ApiController]
    [Route("/halls")]
    public class Halls_Controller : Controller, CRUD_API_Strategy<string, string, string, string>
    {
        [HttpDelete("delete-halls")]
        public Task<ActionResult<string?>> Delete([FromQuery] string? data)
        {
            ////////////////////////////////////////////////////////////////
            //                  !!! DO NOT IMPLEMENT !!!                  //
            ////////////////////////////////////////////////////////////////
            //  MODIFICATIONS TO THE HALLS ARE DONE ONLY IN THE ADMIN APP //
            ////////////////////////////////////////////////////////////////
            return Task.FromResult<ActionResult<string?>>(Content("!!! NOT IMPLEMENTED !!!"));
        }

        [HttpGet("get-halls-page")]
        public async Task<ActionResult<string?>> Get(string? data)
        {
            string? serialised_result = null;

            ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");
            OrderQuery ordered_values = reference.OrderBy("Location");

            if (data != null)
            {
                serialised_result = await ordered_values.EqualTo(data).OnceAsJsonAsync();
            }
            else
            {
                serialised_result = await ordered_values.OnceAsJsonAsync();
            }

            return new ActionResult<string?>(serialised_result);
        }

        [HttpPost("insert-halls")]
        public Task<ActionResult<string?>> Insert(string? data)
        {
            ////////////////////////////////////////////////////////////////
            //                  !!! DO NOT IMPLEMENT !!!                  //
            ////////////////////////////////////////////////////////////////
            //  MODIFICATIONS TO THE HALLS ARE DONE ONLY IN THE ADMIN APP //
            ////////////////////////////////////////////////////////////////
            return Task.FromResult<ActionResult<string?>>(Content("!!! NOT IMPLEMENTED !!!"));
        }

        [HttpPut("update-halls")]
        public Task<ActionResult<string?>> Update(string? data)
        {
            ////////////////////////////////////////////////////////////////
            //                  !!! DO NOT IMPLEMENT !!!                  //
            ////////////////////////////////////////////////////////////////
            //  MODIFICATIONS TO THE HALLS ARE DONE ONLY IN THE ADMIN APP //
            ////////////////////////////////////////////////////////////////
            return Task.FromResult<ActionResult<string?>>(Content("!!! NOT IMPLEMENTED !!!"));
        }
    }
}

