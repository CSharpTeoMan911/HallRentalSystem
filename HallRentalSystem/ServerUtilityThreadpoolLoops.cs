using Firebase.Database;
using Firebase.Database.Query;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HallRentalSystem
{
    public class ServerUtilityThreadpoolLoops
    {
        public int cleanup_cycles_limit { get; set;} = 1;
        public int cleanup_cycles_initiation_interval { get; set; } = 3;


        public void InitiateThreadPoolLoops()
        {
            System.Timers.Timer database_cache_cleanup = new System.Timers.Timer();
            database_cache_cleanup.Elapsed += DatabaseCleanup;
            database_cache_cleanup.Interval = 180000;
            database_cache_cleanup.Start();
        }

        private async void DatabaseCleanup (object? sender, System.Timers.ElapsedEventArgs e)
        {
            await RemoveExpiredLogInSessionKeys();
            await RemoveExpiredPendingTransactions();
            await RemoveExpiredTotalBookingDates();
        }

        private async Task<bool> RemoveExpiredLogInSessionKeys()
        {
            try
            {
                while(true)
                {
                    ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Log_In_Sessions/Log_In_Session_ID");

                    FilterQuery? query = reference.OrderBy("Expiration_Date").EndAt(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm"))).LimitToFirst(1000);

                    Pending_Transactions? values = Newtonsoft.Json.JsonConvert.DeserializeObject<Pending_Transactions>(await query.OnceAsJsonAsync());

                    if (values == null)
                        break;

                    if (Firebase_Database.firebaseClient != null)
                        values?.Keys.ToList().ForEach(async key => await Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID/" + key).DeleteAsync());

                }

            }
            catch(Exception E) { }

            return true;
        }


        private async Task<bool> RemoveExpiredPendingTransactions()
        {
            try
            {
                while (true)
                {
                    ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Pending_Transactions/Pending_Transaction_ID");

                    FilterQuery? query = reference.OrderBy("Expiration_Date").EndAt(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm"))).LimitToFirst(1000);

                    Pending_Transactions? values = Newtonsoft.Json.JsonConvert.DeserializeObject<Pending_Transactions>(await query.OnceAsJsonAsync());

                    if (values == null)
                        break;

                    if (Firebase_Database.firebaseClient != null)
                        values?.Keys.ToList().ForEach(async key => await Firebase_Database.firebaseClient.Child("Pending_Transactions/Pending_Transaction_ID/" + key).DeleteAsync());

                }

            }
            catch (Exception E) { }

            return true;
        }


        private async Task<bool> RemoveExpiredTotalBookingDates()
        {
            try
            {
                while (true)
                {
                    ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Total_Booking_Dates_Keys/Total_Booking_Dates_Keys_ID");
                    FilterQuery? query = reference.OrderBy("Booking_Date").EndAt(Convert.ToInt64(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"))).LimitToFirst(1000);

                    Total_Booking_Dates_Keys? values = Newtonsoft.Json.JsonConvert.DeserializeObject<Total_Booking_Dates_Keys>(await query.OnceAsJsonAsync());

                    if (values == null)
                        break;

                    if (Firebase_Database.firebaseClient != null)
                        values?.Keys.ToList().ForEach(async (key) =>
                        {
                            Total_Booking_Dates_Keys_Values? total_Booking_Dates_Keys_Values = null;
                            values.TryGetValue(key, out total_Booking_Dates_Keys_Values);

                            if(total_Booking_Dates_Keys_Values != null)
                            {
                                StringBuilder query_builder = new StringBuilder();
                                query_builder.Append("Total_Booking_Dates/");
                                query_builder.Append(total_Booking_Dates_Keys_Values.Hall_ID);
                                query_builder.Append("/Booking_Dates/");
                                query_builder.Append(total_Booking_Dates_Keys_Values.Total_Booking_Dates_Child_Database_Key);

                                await Firebase_Database.firebaseClient.Child(query_builder.ToString()).DeleteAsync();

                                query_builder.Clear();
                                query_builder.Append("Total_Booking_Dates_Keys/Total_Booking_Dates_Keys_ID/");
                                query_builder.Append(key);

                                await Firebase_Database.firebaseClient.Child(query_builder.ToString()).DeleteAsync();
                            }
                        });
                }

            }
            catch (Exception E) { }

            return true;
        }

        private void CalculateNecessaryThreadPools()
        {

        }
    }
}
