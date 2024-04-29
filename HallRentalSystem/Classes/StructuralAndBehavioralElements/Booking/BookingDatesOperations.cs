using Firebase.Database;
using Firebase.Database.Query;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using Microsoft.Extensions.Primitives;
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
                query_builder.Append("/Booking_Dates/");

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
                            foreach (long date in data.booking_dates)
                            {
                                StringBuilder query_builder = new StringBuilder();
                                query_builder.Append("Total_Booking_Dates/");
                                query_builder.Append(data.Hall_ID);
                                query_builder.Append("/Booking_Dates/");

                                Total_Booking_Dates_Values total_Booking_Dates_Values = new Total_Booking_Dates_Values();
                                total_Booking_Dates_Values.Booking_Date = date;

                                ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());
                                FirebaseObject<Total_Booking_Dates_Values>? query_result = await total_dates_database_reference.PostAsync(total_Booking_Dates_Values);
                                
                                if(query_result != null)
                                {
                                    Total_Booking_Dates_Keys_Values total_Booking_Dates_Keys_Values = new Total_Booking_Dates_Keys_Values();
                                    total_Booking_Dates_Keys_Values.Total_Booking_Dates_Child_Database_Key = query_result.Key;
                                    total_Booking_Dates_Keys_Values.Booking_Date = date;
                                    total_Booking_Dates_Keys_Values.Hall_ID = data.Hall_ID;

                                    ChildQuery? total_dates_database_keys_reference = Firebase_Database.firebaseClient?.Child("Total_Booking_Dates_Keys/Total_Booking_Dates_Keys_ID");
                                    await total_dates_database_keys_reference.PostAsync(total_Booking_Dates_Keys_Values);
                                }
                                else
                                {
                                    result = "Internal server error";
                                }

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
                            foreach (long date in data.booking_dates)
                            {
                                StringBuilder query_builder = new StringBuilder();
                                query_builder.Append("Total_Booking_Dates/");
                                query_builder.Append(data.Hall_ID);
                                query_builder.Append("/Booking_Dates/");

                                Total_Booking_Dates_Values total_Booking_Dates_Values = new Total_Booking_Dates_Values();
                                total_Booking_Dates_Values.Booking_Date = date;

                                ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());
                                FirebaseObject<Total_Booking_Dates_Values>? query_result = await total_dates_database_reference.PostAsync(total_Booking_Dates_Values);

                                if (query_result != null)
                                {
                                    Total_Booking_Dates_Keys_Values total_Booking_Dates_Keys_Values = new Total_Booking_Dates_Keys_Values();
                                    total_Booking_Dates_Keys_Values.Total_Booking_Dates_Child_Database_Key = query_result.Key;
                                    total_Booking_Dates_Keys_Values.Booking_Date = date;
                                    total_Booking_Dates_Keys_Values.Hall_ID = data.Hall_ID;

                                    ChildQuery? total_dates_database_keys_reference = Firebase_Database.firebaseClient?.Child("Total_Booking_Dates_Keys/Total_Booking_Dates_Keys_ID");
                                    await total_dates_database_keys_reference.PostAsync(total_Booking_Dates_Keys_Values);
                                }
                                else
                                {
                                    result = "Internal server error";
                                }

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
