using HallRentalSystem.Classes.API_Parameters;
using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking
{
    public class BookingOperations : CRUD_Strategy<Booking_Parameters, string, Bookings, string>
    {
        public Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Get<ReturnType>(string? data)
        {
            //Firebase.Firebase_Database.firebaseClient.
            throw new NotImplementedException();
        }

        public async Task<ReturnType?> Insert<ReturnType>(Booking_Parameters? data)
        {

            return (ReturnType)(object)"Ok";
            //throw new NotImplementedException();
        }

        public Task<ReturnType?> Update<ReturnType>(Bookings? data)
        {
            throw new NotImplementedException();
        }
    }
}
