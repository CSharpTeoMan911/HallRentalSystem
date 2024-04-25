using Firebase.Database.Query;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using System.Text;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking
{
    public class BookingDatesOperations : CRUD_Strategy<TotalBookingDatesParameters, string, TotalBookingDatesParameters, string>
    {
        public async Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            string? result = "Internal server error";

            try
            {
                StringBuilder query_builder = new StringBuilder();
                query_builder.Append("Total_Booking_Dates/");
                query_builder.Append(data);

                ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());
                
                if(total_dates_database_reference != null)
                    await total_dates_database_reference.DeleteAsync();

                result = "Dates deleted successfully";
            }
            catch { }


            return (ReturnType)(object)result;
        }

        public async Task<ReturnType?> Get<ReturnType>(string? data)
        {
            string? result = "Internal server error";

            try
            {
                StringBuilder query_builder = new StringBuilder();
                query_builder.Append("Total_Booking_Dates/");
                query_builder.Append(data);

                ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());

                string? json_result = null;

                if (total_dates_database_reference != null)
                    json_result = await total_dates_database_reference.OnceAsJsonAsync();

                if (json_result != null)
                    result = json_result;
            }
            catch { }


            return (ReturnType)(object)result;
        }

        public async Task<ReturnType?> Insert<ReturnType>(TotalBookingDatesParameters? data)
        {
            string result = "Update succeeded";

            try
            {
                if (data != null)
                {
                    if (data.Hall_ID != null)
                    {
                        if (data.booking_dates != null)
                        {
                            foreach (DateOnly date in data.booking_dates)
                            {
                                StringBuilder query_builder = new StringBuilder();
                                query_builder.Append("Total_Booking_Dates/");
                                query_builder.Append(data.Hall_ID);
                                query_builder.Append("/");
                                query_builder.Append(date.ToString("yyyyMMdd"));

                                ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());
                                await total_dates_database_reference.PostAsync(true);
                            }
                        }
                        else
                        {
                            result = "Internal server error";
                        }
                    }
                    else
                    {
                        result = "Internal server error";
                    }
                }
                else
                {
                    result = "Internal server error";

                }
            }
            catch
            {
                result = "Internal server error";
            }

            return (ReturnType)(object)result;
        }

        public async Task<ReturnType?> Update<ReturnType>(TotalBookingDatesParameters? data)
        {
            string result = "Update succeeded";

            try
            {
                if (data != null)
                {
                    if (data.Hall_ID != null)
                    {
                        if (data.booking_dates != null)
                        {
                            foreach (DateOnly date in data.booking_dates)
                            {
                                StringBuilder query_builder = new StringBuilder();
                                query_builder.Append("Total_Booking_Dates/");
                                query_builder.Append(data.Hall_ID);
                                query_builder.Append("/");
                                query_builder.Append(date.ToString("yyyyMMdd"));

                                ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());
                                await total_dates_database_reference.PostAsync(true);
                            }
                        }
                        else
                        {
                            result = "Internal server error";
                        }
                    }
                    else
                    {
                        result = "Internal server error";
                    }
                }
                else
                {
                    result = "Internal server error";

                }
            }
            catch
            {
                result = "Internal server error";
            }

            return (ReturnType)(object)result;
        }
    }
}
