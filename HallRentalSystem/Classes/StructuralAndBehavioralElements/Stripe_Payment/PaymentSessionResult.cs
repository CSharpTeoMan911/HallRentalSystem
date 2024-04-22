namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Stripe_Payment
{
    public class PaymentSessionResult
    {
        public string? status { get; set; }
        public string? payment_intent_id_database_key { get; set; }
        public string? redirection_url { get; set; }
    }
}
