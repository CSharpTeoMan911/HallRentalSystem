using Microsoft.AspNetCore.Mvc;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Booking
{
    public class BookingOperations : CRUD_Strategy<Bookings, string, Bookings, string>
    {
        public Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Get<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Insert<ReturnType>(Bookings? data)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnType?> Update<ReturnType>(Bookings? data)
        {
            throw new NotImplementedException();
        }
    }
}
