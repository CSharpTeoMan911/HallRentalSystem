using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public class AuthenticationStateManager:CRUD_Strategy<Tuple<ProtectedLocalStorage, string>, ProtectedLocalStorage, Tuple<ProtectedLocalStorage, string>, ProtectedLocalStorage>
    {
        public async Task<ReturnType?> Delete<ReturnType>(ProtectedLocalStorage? data)
        {
            if (data != null)
                await data.DeleteAsync("HallRental_Auth_Cache");
            return (ReturnType)(object)true;
        }

        public async Task<ReturnType?> Get<ReturnType>(ProtectedLocalStorage? data)
        {
            if (data != null)
            {
                ProtectedBrowserStorageResult<string> cache = await data.GetAsync<string>("HallRental_Auth_Cache");

                if (cache.Value != null)
                {
                    if (Shared_Data.authentication_state != Shared_Data.AuthState.Logout)
                    {
                        Shared_Data.authentication_state = Shared_Data.AuthState.Logout;
                        return (ReturnType)(object)true;
                    }
                    else
                    {
                        return (ReturnType)(object)false;
                    }
                }
                else
                {
                    if (Shared_Data.authentication_state != Shared_Data.AuthState.Login)
                    {
                        Shared_Data.authentication_state = Shared_Data.AuthState.Login;
                        return (ReturnType)(object)true;
                    }
                    else
                    {
                        return (ReturnType)(object)false;
                    }
                }
            }
            else
            {
                return (ReturnType)(object)false;
            }
        }

        public async Task<ReturnType?> Insert<ReturnType>(Tuple<ProtectedLocalStorage, string>? data)
        {
            if (data != null)
                await data.Item1.SetAsync("HallRental_Auth_Cache", data.Item2);
            return (ReturnType)(object)true;
        }

        public async Task<ReturnType?> Update<ReturnType>(Tuple<ProtectedLocalStorage, string>? data)
        {
            if(data != null)
                await data.Item1.SetAsync("HallRental_Auth_Cache", data.Item2);
            return (ReturnType)(object)true;
        }
    }
}
