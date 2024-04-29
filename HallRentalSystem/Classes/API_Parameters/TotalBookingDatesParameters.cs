namespace HallRentalSystem.Classes.API_Parameters
{
    public class TotalBookingDatesParameters
    {
        public string? Hall_ID { get; set; }
        public List<long>? booking_dates { get; set; }
    }
}
