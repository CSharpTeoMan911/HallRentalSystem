using Stripe;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Stripe_Payment
{
    public class PaymentResult
    {
        public PaymentIntent? payment_intent { get; set; }
        public string? payment_operation_result { get; set; }
    }
}
