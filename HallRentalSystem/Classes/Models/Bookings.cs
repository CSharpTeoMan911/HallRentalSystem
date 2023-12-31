namespace HallRentalSystem.Classes
{
    public class Bookings
    {
        public string? Booking_ID { get; set; }
        public string? Customer_ID { get; set; }
        public string? Hall_ID { get; set; }
        public DateTime Booking_Date { get; set; }
        public DateTime Rental_Date { get; set; }
        public int Booking_Duration { get; set; }
        public int Cost { get; set; }
    }
}
