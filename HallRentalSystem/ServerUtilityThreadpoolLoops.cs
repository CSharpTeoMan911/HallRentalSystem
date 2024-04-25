using Firebase.Database;
using Firebase.Database.Query;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
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

                    FilterQuery? query = reference.OrderBy("Expiration_Date").EndAt(Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmm"))).LimitToFirst(1);

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

        private void CalculateNecessaryThreadPools()
        {

        }
    }
}
