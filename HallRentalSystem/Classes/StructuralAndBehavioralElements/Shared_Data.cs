using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Stripe_Payment;
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

        public enum BookingError
        {
            InsufficientDates,
            PaymentError,
            InvalidHallObject,
            MissingRequiredData,
            LogInSessionKeyExpired,
            InvalidEmailAddress
        }

        public enum PaymentStatus
        {
            PaymentSucceeded,
            RequiresAction
        }

        public static readonly CRUD_Context<Customer_ID_Value, Customer_ID_Value, Customers, string> authentication = new CRUD_Context<Customer_ID_Value, Customer_ID_Value, Customers, string>(new CredentialsOperations());
        public static readonly CRUD_Context<Log_In_Session_ID_Value, FirebaseKey, string, FirebaseKey> log_in_session = new CRUD_Context<Log_In_Session_ID_Value, FirebaseKey, string, FirebaseKey>(new LoginSessionKeyOperations());
        public static readonly CRUD_Context<Booking_Parameters, string, Bookings, string> bookings = new CRUD_Context<Booking_Parameters, string, Bookings, string>(new BookingOperations());
        public static readonly CRUD_Context<Booking_Parameters, Payment_Parameters, string, string> stripe_payments = new CRUD_Context<Booking_Parameters, Payment_Parameters, string, string>(new Stripe_Operations());
        public static readonly CRUD_Context<TotalBookingDatesParameters, string, TotalBookingDatesParameters, string> total_bookings = new CRUD_Context<TotalBookingDatesParameters, string, TotalBookingDatesParameters, string>(new BookingDatesOperations());

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
