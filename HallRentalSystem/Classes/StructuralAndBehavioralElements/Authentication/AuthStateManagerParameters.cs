using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    public class AuthStateManagerParameters
    {
        public ProtectedLocalStorage? localStorage { get; set; }
        public string? log_in_session_key { get; set; }
    }
}
