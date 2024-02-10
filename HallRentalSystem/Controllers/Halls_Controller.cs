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


        // GET THE HALLS OBJECTS WITHIN THE DATABASE
        [HttpGet("get-halls-page")]
        public async Task<ActionResult<string?>> Get(string? data)
        {
            string? serialised_result = null;

            // CREATE A REFERENCE TO THE DATABASE NODE THAT STORES THE HALLS
            ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");

            // ORDER THE HALLS BY LOCATION
            OrderQuery ordered_values = reference.OrderBy("Location");

            // IF THE LOCATION PARAMETER IS NOT NULL
            if (data != null)
            {
                // GET THE HALLS THAT HAVE THEIR LOCATION PROPRIETY FIELD EQUAL WITH THE
                // SELECTED LOCATION PARAMETER AND SERIALIZE THEM IN A JSON OBJECT
                serialised_result = await ordered_values.EqualTo(data).OnceAsJsonAsync();
            }
            // IF THE LOCATION PARAMETER IS NULL
            else
            {
                // GET THE HALLS AND SERIALIZE THEM IN A JSON OBJECT
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

