using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Stripe_Payment;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Controllers
{
    [Route("/stripe")]
    public class Payments_Controller : Controller, CRUD_API_Strategy<PaymentSessionResult, Payment_Parameters, PaymentSessionResult, PaymentSessionResult>
    {
        [HttpDelete("delete")]
        public Task<ActionResult<string?>> Delete(PaymentSessionResult? data)
        {
            throw new NotImplementedException();
        }

        [HttpGet("get")]
        public async Task<ActionResult<string?>> Get(Payment_Parameters? data)
        {
            string? result = await Shared_Data.stripe_payments.Get<string>(data);
            return (ActionResult<string?>)result;
        }

        [HttpPost("post")]
        public Task<ActionResult<string?>> Insert(PaymentSessionResult? data)
        {
            throw new NotImplementedException();
        }

        [HttpPut("post")]
        public Task<ActionResult<string?>> Update(PaymentSessionResult? data)
        {
            throw new NotImplementedException();
        }
    }
}
