using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements
{
    public class Shared_Data : ComponentBase
    {
        public enum AuthState
        {
            Login,
            Logout
        }
        public static AuthState authentication_state = AuthState.Login;
        public static CRUD_Context<string, string, string, string> pagination_manager = new CRUD_Context<string, string, string, string>(new HallsPaginationStateManager());
        public static CRUD_Context<Tuple<ProtectedLocalStorage, string>, ProtectedLocalStorage, Tuple<ProtectedLocalStorage, string>, ProtectedLocalStorage> auth_manager = new CRUD_Context<Tuple<ProtectedLocalStorage, string>, ProtectedLocalStorage, Tuple<ProtectedLocalStorage, string>, ProtectedLocalStorage>(new AuthenticationStateManager());
    }
}
