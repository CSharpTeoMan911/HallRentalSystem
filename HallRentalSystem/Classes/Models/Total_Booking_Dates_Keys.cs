namespace HallRentalSystem.Classes.Models
{
    public class Total_Booking_Dates_Keys_Values
    {
        public long Booking_Date { get; set; }
        public string? Hall_ID { get; set; }
        public string? Total_Booking_Dates_Child_Database_Key { get; set; }
    }
    public class Total_Booking_Dates_Keys:Dictionary<string, Total_Booking_Dates_Keys_Values> { }
}
