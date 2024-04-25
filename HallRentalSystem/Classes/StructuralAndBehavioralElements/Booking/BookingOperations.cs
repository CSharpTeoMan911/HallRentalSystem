using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using HallRentalSystem.Classes.API_Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Stripe_Payment;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using Firebase.Database.Query;
using HallRentalSystem.Classes.Models;
using Firebase.Database;
using System.Security.Cryptography.Xml;
using System.Text;

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
            try
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


                                if (log_in_session_key_verification_result != "Internal server error" && log_in_session_key_verification_result != "Invalid login session key" && log_in_session_key_verification_result != "Log in session key expired")
                                {

                                    PaymentResult? stripe_payment_result = await Shared_Data.stripe_payments.Insert<PaymentResult>(data);


                                    if (stripe_payment_result != null)
                                    {
                                        if (stripe_payment_result?.payment_operation_result == "Payment procedure initiated")
                                        {
                                            PaymentSessionResult paymentSessionResult = new PaymentSessionResult();
                                            paymentSessionResult.status = stripe_payment_result?.payment_intent?.Status;



                                            ChildQuery? halls_database_reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");
                                            string serialised_values = await halls_database_reference.Child(data.Hall_ID).OnceAsJsonAsync();
                                            Hall_ID_Value? deserialised_values = Newtonsoft.Json.JsonConvert.DeserializeObject<Hall_ID_Value>(serialised_values);



                                            if (deserialised_values != null)
                                            {
                                                if (stripe_payment_result?.payment_intent?.Status == "succeeded")
                                                {
                                                    string? serialisedPaymentSessionResult = Newtonsoft.Json.JsonConvert.SerializeObject(paymentSessionResult);


                                                    Booking_ID_Value booking = new Booking_ID_Value();
                                                    booking.Customer_ID = log_in_session_key_verification_result;
                                                    booking.Rental_Dates = data.rental_dates;
                                                    booking.Hall_ID = data.Hall_ID;
                                                    booking.Amount = deserialised_values.Price * data.rental_dates.Count;
                                                    booking.Payment_Intent_ID = stripe_payment_result?.payment_intent?.Id;



                                                    ChildQuery? bookings_database_reference = Firebase_Database.firebaseClient?.Child("Bookings/Booking_ID");
                                                    await bookings_database_reference.PostAsync(booking);


                                                    List<long> booking_dates = new List<long>();


                                                    foreach (DateOnly date in data.rental_dates)
                                                    {
                                                        booking_dates.Add(Convert.ToInt64(date.ToString("yyyyMMdd")));
                                                    }


                                                    StringBuilder query_builder = new StringBuilder();
                                                    query_builder.Append("Total_Booking_Dates/");
                                                    query_builder.Append(data.Hall_ID);


                                                    ChildQuery? total_dates_database_reference = Firebase_Database.firebaseClient?.Child(query_builder.ToString());
                                                    await total_dates_database_reference.PostAsync(booking_dates);


                                                    return (ReturnType)(object)serialisedPaymentSessionResult;

                                                }
                                                else if (stripe_payment_result?.payment_intent?.Status == "requires_action")
                                                {
                                                    DateTime current_date_time = DateTime.Now.AddMinutes(5);

                                                    Pending_Transactions_Values pending_Transactions_Values = new Pending_Transactions_Values();
                                                    pending_Transactions_Values.Payment_Intent_ID = stripe_payment_result?.payment_intent?.Id;
                                                    pending_Transactions_Values.Expiration_Date = Convert.ToInt64(current_date_time.ToString("yyyyMMddHHmm"));
                                                    pending_Transactions_Values.Customer_ID = log_in_session_key_verification_result;
                                                    pending_Transactions_Values.Rental_Dates = data.rental_dates;
                                                    pending_Transactions_Values.Hall_ID = data.Hall_ID;
                                                    pending_Transactions_Values.Amount = deserialised_values.Price * data.rental_dates.Count;



                                                    string? serialised_Pending_Transactions_Values = Newtonsoft.Json.JsonConvert.SerializeObject(pending_Transactions_Values);


                                                    if (serialised_Pending_Transactions_Values != null)
                                                    {
                                                        ChildQuery? database_reference = Firebase_Database.firebaseClient?.Child("Pending_Transactions/Pending_Transaction_ID");
                                                        FirebaseObject<Pending_Transactions_Values> result = await database_reference.PostAsync(pending_Transactions_Values);


                                                        paymentSessionResult.redirection_url = stripe_payment_result?.payment_intent?.NextAction?.RedirectToUrl.Url;
                                                        paymentSessionResult.payment_intent_id_database_key = result.Key;


                                                        string? serialisedPaymentSessionResult = Newtonsoft.Json.JsonConvert.SerializeObject(paymentSessionResult);


                                                        if (serialisedPaymentSessionResult != null)
                                                        {
                                                            return (ReturnType)(object)serialisedPaymentSessionResult;
                                                        }
                                                        else
                                                        {
                                                            return (ReturnType)(object)"Internal server error";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        return (ReturnType)(object)"Internal server error";
                                                    }
                                                }
                                                else
                                                {
                                                    return (ReturnType)(object)"Payment unsuccessful";
                                                }
                                            }
                                            else
                                            {
                                                return (ReturnType)(object)"Internal server error";
                                            }

                                        }
                                        else
                                        {
                                            if (stripe_payment_result?.payment_operation_result != null)
                                            {
                                                return (ReturnType)(object)stripe_payment_result.payment_operation_result;
                                            }
                                            else
                                            {
                                                return (ReturnType)(object)"Internal server error";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return (ReturnType)(object)"Internal server error";
                                    }
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
            catch
            {
                return (ReturnType)(object)"Internal server error";
            }
        }

        public Task<ReturnType?> Update<ReturnType>(Bookings? data)
        {
            throw new NotImplementedException();
        }
    }
}
