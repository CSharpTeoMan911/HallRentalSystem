namespace HallRentalSystem.Classes.DTO
{
    public class Payments
    {
        public string? Payment_ID { get; set; }
        public string? Booking_ID { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
