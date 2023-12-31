using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public class AuthenticationStateManager
    {
        protected static async Task<bool> _Get_If_User_Is_Logged_In(ProtectedLocalStorage LocalStorage)
        {
            ProtectedBrowserStorageResult<string> cache = await LocalStorage.GetAsync<string>("HallRental_Auth_Cache");

            if (cache.Value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected static async Task<bool> _Set_If_User_Is_Logged_In(ProtectedLocalStorage LocalStorage, string cache)
        {
            await LocalStorage.SetAsync("HallRental_Auth_Cache", cache);
            return true;
        }
    }
}
