using HallRentalSystem.Classes.StructuralAndBehavioralElements.Page_Navigation;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HallRentalSystem.Controllers
{
    [Firebase_Database]
    [ApiController]
    [Route("/halls")]
    public class Halls_Controller : Controller, CRUD_API_Strategy<string, Halls_Pagination, string, string>
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
        public async Task<ActionResult<string?>> Get([FromQuery] Halls_Pagination? data)
        {
            Console.WriteLine("Location: " + data.location_filter);
            Console.WriteLine("Page: " + data.page_index);
            int elements_per_page = 50;
            string? serialised_result = null;

            switch (data?.page_index)
            {
                case -1:
                    serialised_result = await Halls_Page_Navigation.Navigate_To_Previous_Page(data, elements_per_page);
                    break;
                case 0:
                    serialised_result = await Halls_Page_Navigation.Navigate_To_Current_Page(data, elements_per_page);
                    break;
                case 1:
                    serialised_result = await Halls_Page_Navigation.Navigate_To_Next_Page(data, elements_per_page);
                    break;
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

