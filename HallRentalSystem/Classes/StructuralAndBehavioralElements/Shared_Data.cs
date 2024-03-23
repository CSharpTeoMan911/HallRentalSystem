using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking;
using Microsoft.AspNetCore.Components;

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

        public static CRUD_Context<Customer_ID_Value, Customer_ID_Value, Customers, string> authentication = new CRUD_Context<Customer_ID_Value, Customer_ID_Value, Customers, string>(new CredentialsOperations());
        public static CRUD_Context<Log_In_Session_ID_Value, string, string, FirebaseKey> log_in_session = new CRUD_Context<Log_In_Session_ID_Value, string, string, FirebaseKey>(new LoginSessionKeyOperations());
        public static CRUD_Context<Bookings, string, Bookings, string> bookings = new CRUD_Context<Bookings, string, Bookings, string>(new BookingOperations());

        public static HttpClient GenerateHttpCLient(){
            if(Program.EnableSSL == true)
            {
                return new HttpClient();
            }
            else
            {
                HttpClientHandler http_client_handler = new HttpClientHandler(){
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback = 
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    }
                };
                return new HttpClient(http_client_handler);
            }
        }
    }
}
