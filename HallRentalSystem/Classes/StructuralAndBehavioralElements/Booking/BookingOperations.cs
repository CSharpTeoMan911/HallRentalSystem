using HallRentalSystem.Classes.StructuralAndBehavioralElements;
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
            if (data?.Hall_ID != null)
            {
                if (data?.stripe_payment_method != null)
                {
                    if (data?.key != null)
                    {
                        if (data?.rental_dates?.Count > 0)
                        {
                            string? log_in_session_key_verification_result = await Shared_Data.log_in_session.Get<string>(data.key);
                            
                            if (log_in_session_key_verification_result == "Valid login session key")
                            {
                                ///////////////////
                                // !!! TO DO !!! //
                                ///////////////////
                                

                                Bookings booking = new Bookings();

                                return (ReturnType)(object)"Internal server error";
                            }
                            else
                            {
                                if (log_in_session_key_verification_result != null)
                                {
                                    return (ReturnType)(object)log_in_session_key_verification_result;
                                }
                                else
                                {
                                    return (ReturnType)(object)"Internal server error";
                                }
                            }
                        }
                        else
                        {
                            return (ReturnType)(object)"Missing required data";
                        }
                    }
                    else
                    {
                        return (ReturnType)(object)"Missing required data";
                    }
                }
                else
                {
                    return (ReturnType)(object)"Missing required data";
                }
            }
            else
            {
                return (ReturnType)(object)"Missing required data";
            }
        }

        public Task<ReturnType?> Update<ReturnType>(Bookings? data)
        {
            throw new NotImplementedException();
        }
    }
}
