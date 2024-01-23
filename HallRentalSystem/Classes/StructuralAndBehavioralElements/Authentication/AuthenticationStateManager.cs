using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    public class AuthenticationStateManager : CRUD_Strategy<AuthStateManagerParameters, ProtectedLocalStorage, AuthStateManagerParameters, ProtectedLocalStorage>
    {
        public async Task<ReturnType?> Delete<ReturnType>(ProtectedLocalStorage? data)
        {
            if (data != null)
            {
                try
                {
                    await data.DeleteAsync("HallRental_Auth_Cache");
                }
                catch{}
            }
            return (ReturnType)(object)true;
        }

        public async Task<ReturnType?> Get<ReturnType>(ProtectedLocalStorage? data)
        {
            if (data != null)
            {
                try
                {
                    ProtectedBrowserStorageResult<string> cache = await data.GetAsync<string>("HallRental_Auth_Cache");
                    if(cache.Value != null)
                    {
                        return (ReturnType)(object)cache.Value;
                    }
                    else
                    {
                        return (ReturnType)(object)String.Empty;
                    }
                }
                catch
                {
                    return (ReturnType)(object)String.Empty;
                }
            }
            else
            {
                return (ReturnType)(object)String.Empty;
            }
        }

        public async Task<ReturnType?> Insert<ReturnType>(AuthStateManagerParameters? data)
        {
            if (data != null)
            {
                if (data.log_in_session_key != null)
                {
                    if (data.localStorage != null)
                    {
                        try
                        {
                            await data.localStorage.SetAsync("HallRental_Auth_Cache", data.log_in_session_key);
                        }
                        catch{}
                    }
                }
            }
            return (ReturnType)(object)true;
        }

        public async Task<ReturnType?> Update<ReturnType>(AuthStateManagerParameters? data)
        {
            if (data != null)
            {
                if (data.log_in_session_key != null)
                {
                    if (data.localStorage != null)
                    {
                        try
                        {
                            await data.localStorage.SetAsync("HallRental_Auth_Cache", data.log_in_session_key);
                        }
                        catch{}
                    }
                }
            }
            return (ReturnType)(object)true;
        }
    }
}
