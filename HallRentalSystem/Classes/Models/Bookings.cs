namespace HallRentalSystem.Classes
{
    public class Booking_ID_Value
    {
        public string? Customer_ID { get; set; }
        public string? Hall_ID { get; set; }
        public string? Stripe_Payment_ID { get; set; }
        public long Amount { get; set; }
        public List<DateTime>? Rental_Dates { get; set; }
    }

    public class Bookings:Dictionary<string, Booking_ID_Value> { }
}
