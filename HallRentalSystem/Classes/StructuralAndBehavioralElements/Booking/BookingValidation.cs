using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking
{
    public class BookingValidation
    {
        public static async Task<string> VerifyIfBookingIsValid(List<DateOnly> rental_dates, string hall_id)
        {
            string result = "Booking verification successful";

            string? serialised_reserved_dates = await Shared_Data.total_bookings.Get<string>(hall_id);

            if (serialised_reserved_dates != "Internal server error" && serialised_reserved_dates != null)
            {
                Total_Booking_Dates_Values? reserved_dates = Newtonsoft.Json.JsonConvert.DeserializeObject<Total_Booking_Dates_Values>(serialised_reserved_dates);

                if (reserved_dates != null)
                {
                    foreach (long Date in reserved_dates.Keys)
                    {
                        foreach (DateOnly date in rental_dates)
                        {
                            if (Convert.ToInt64(date.ToString("yyyyMMdd")) == Date)
                            {
                                result = "Internal server error";
                                break;
                            }
                        }
                    }
                }

            }
            else
            {
                result = "Internal server error";
            }

            return result;
        }
    }
}
