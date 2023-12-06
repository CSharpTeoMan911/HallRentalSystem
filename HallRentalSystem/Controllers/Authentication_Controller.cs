using HallRentalSystem.Classes.DTO;
using HallRentalSystem.Classes;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class Authentication_Controller : Controller, CRUD_Strategy<Customers, Customers, Customers, Customers, ActionResult<string>>
    {
        [HttpDelete("delete-account")]
        public Task<ActionResult<string>> Delete(Customers? data)
        {
            throw new NotImplementedException();
        }

        [HttpGet("get-account")]
        public Task<ActionResult<string>> Get(Customers? data)
        {
            throw new NotImplementedException();
        }

        [HttpPost("insert-account")]
        public Task<ActionResult<string>> Insert(Customers? data)
        {
            throw new NotImplementedException();
        }

        [HttpPut("update-account")]
        public Task<ActionResult<string>> Update(Customers? data)
        {
            throw new NotImplementedException();
        }
    }
}
