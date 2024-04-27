namespace HallRentalSystem.Classes.Models
{
    public class Total_Booking_Dates_Values
    {
        public long Booking_Date { get; set; }
    }
    public class Total_Booking_Dates:Dictionary<string, Total_Booking_Dates_Values> { }
}
