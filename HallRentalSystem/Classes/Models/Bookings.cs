namespace HallRentalSystem.Classes
{
    public class Bookings
    {
        public string? Booking_ID { get; set; }
        public string? Customer_ID { get; set; }
        public string? Hall_ID { get; set; }
        public string? Stripe_Payment_ID { get; set; }
        public long Amount { get; set; }
        public List<DateTime>? Rental_Dates { get; set; }
    }
}
