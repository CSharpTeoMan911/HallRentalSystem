namespace HallRentalSystem.Classes.Models
{
    public class Total_Rental_Dates_Values
    {
        public List<long>? booking_dates { get;set; }
    }

    public class Total_Rental_Dates:Dictionary<string, Total_Rental_Dates_Values>{ }
}
