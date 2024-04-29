namespace HallRentalSystem.Classes
{
    public class Booking_ID_Value
    {
        public string? Customer_ID { get; set; }
        public string? Hall_ID { get; set; }
        public string? Payment_Intent_ID { get; set; }
        public long Amount { get; set; }
        public List<long>? Rental_Dates { get; set; }
    }

    public class Bookings:Dictionary<string, Booking_ID_Value> { }
}
