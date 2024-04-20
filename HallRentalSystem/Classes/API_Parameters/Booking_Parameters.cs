namespace HallRentalSystem.Classes.API_Parameters
{
    public class Booking_Parameters
    {
        public string? Hall_ID { get; set; }
        public string? stripe_payment_method { get; set; }
        public List<DateOnly>? rental_dates { get; set; }
        public FirebaseKey? key { get; set; }
    }
}
