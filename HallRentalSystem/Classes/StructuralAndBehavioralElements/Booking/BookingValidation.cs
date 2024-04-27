using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking
{
    public class BookingValidation
    {
        public static async Task<string> VerifyIfBookingIsValid(List<DateOnly> rental_dates, string hall_id)
        {
            string? serialised_reserved_dates = await Shared_Data.total_bookings.Get<string>(hall_id);


            if (serialised_reserved_dates != "Internal server error" && serialised_reserved_dates != null)
            {
                Total_Booking_Dates? reserved_dates = Newtonsoft.Json.JsonConvert.DeserializeObject<Total_Booking_Dates>(serialised_reserved_dates);

                if (reserved_dates != null)
                {
                    foreach (string key in reserved_dates.Keys)
                    {
                        Total_Booking_Dates_Values? total_Booking_Dates_Values = new Total_Booking_Dates_Values();
                        reserved_dates.TryGetValue(key, out total_Booking_Dates_Values);

                        if (total_Booking_Dates_Values != null)
                        {
                            foreach (DateOnly date in rental_dates)
                            {
                                if (Convert.ToInt64(date.ToString("yyyyMMdd")) == total_Booking_Dates_Values.Booking_Date)
                                {
                                    return "Date already in use";
                                }
                            }
                        }
                        else
                        {
                            return "Internal server error";
                        }
                    }

                    return "Booking verification successful";
                }
                else
                {
                    return "Booking verification successful";
                }
            }
            else
            {
                return "Internal server error";
            }
        }
    }
}
