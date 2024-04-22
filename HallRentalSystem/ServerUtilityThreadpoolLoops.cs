using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;

namespace HallRentalSystem
{
    public class ServerUtilityThreadpoolLoops
    {
        public void InitiateThreadPoolLoops()
        {
            System.Timers.Timer database_cache_cleanup = new System.Timers.Timer();
            database_cache_cleanup.Elapsed += DatabaseCleanup;
            database_cache_cleanup.Interval = 10000;
            database_cache_cleanup.Start();
        }

        private async void DatabaseCleanup (object? sender, System.Timers.ElapsedEventArgs e)
        {
            await RemoveExpiredLogInSessionKeys();
            await RemoveExpiredPendingTransactions();
        }

        private Task<bool> RemoveExpiredLogInSessionKeys()
        {
            //Firebase_Database.firebaseClient.Child();
            return Task.FromResult(true);
        }

        private Task<bool> RemoveExpiredPendingTransactions()
        {
            return Task.FromResult(true);
        }

        private void CalculateNecessaryThreadPools()
        {

        }
    }
}
