using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes
{
    public class Shared_Data : ComponentBase
    {
        protected static string authentication_state = "Login";
        protected class Shared_Functions
        {
            public class AuthenticationStateManagerFunctions: AuthenticationStateManager
            {
                public static async Task<bool> Get_If_User_Is_Logged_In(ProtectedLocalStorage LocalStorage)
                {
                    if(await _Get_If_User_Is_Logged_In(LocalStorage) == true)
                    {
                        if (authentication_state != "Logout")
                        {
                            authentication_state = "Logout";
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (authentication_state != "Login")
                        {
                            authentication_state = "Login";
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}
