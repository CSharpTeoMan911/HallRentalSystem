using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [Route("/auth/login")]
    [ApiController]
    public class Login_Controller : Controller
    {
        [HttpPost("insert")]
        public string PostAccount()
        {
            return "Hi there!";
        }
    }
}
