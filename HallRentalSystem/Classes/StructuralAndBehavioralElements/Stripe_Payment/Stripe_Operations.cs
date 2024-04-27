using Firebase.Database;
using Firebase.Database.Query;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using Stripe;
using System.Text;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Stripe_Payment
{
    public class Stripe_Operations : CRUD_Strategy<Booking_Parameters, string, string, string>
    {
        public Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnType?> Get<ReturnType>(string? data)
        {
            string? result = "Payment confirmation successful";

            if (data != null)
            {
                ChildQuery? database_reference = Firebase_Database.firebaseClient?.Child("Pending_Transactions/Pending_Transaction_ID");

                if (database_reference != null)
                {
                    Console.WriteLine(await database_reference.OrderByKey().EqualTo(data).OnceAsJsonAsync());
                }
                else
                {
                    result = "Internal server error";
                }
            }
            else
            {
                result = "Invalid database key";
            }

            return (ReturnType)(object)result;
        }

        public async Task<ReturnType?> Insert<ReturnType>(Booking_Parameters? data)
        {
            PaymentResult result = new PaymentResult();

            if (data != null)
            {
                if (data?.stripe_payment_method != null)
                {
                    if (data?.return_uri != null)
                    {
                        if (data?.key != null)
                        {
                            if (data?.rental_dates != null)
                            {
                                if (data?.Hall_ID != null)
                                {
                                    try
                                    {
                                        StripeConfiguration.ApiKey = "sk_test_51P6efVRsFLK70EkgYWGtEqm6NSOsDu7kWgEOqfN9mgZNrLn6VFxCJVW6QFKJsmuyaxUHVOrbBgu8Cql7U0aLidYm00tab4koXy";

                                        ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");

                                        if (reference != null)
                                        {
                                            string serialised_values = await reference.Child(data.Hall_ID).OnceAsJsonAsync();

                                            Hall_ID_Value? deserialised_values = Newtonsoft.Json.JsonConvert.DeserializeObject<Hall_ID_Value>(serialised_values);

                                            if (deserialised_values != null)
                                            {
                                                PaymentIntentService service = new PaymentIntentService();

                                                string payment_intent_id = (await service.CreateAsync(new PaymentIntentCreateOptions
                                                {
                                                    Amount = deserialised_values.Price * data?.rental_dates?.Count * 100,
                                                    Currency = "gbp",
                                                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                                                    {
                                                        Enabled = true,
                                                    },
                                                })).Id;

                                                PaymentIntent paymentIntent = await service.ConfirmAsync(payment_intent_id, new PaymentIntentConfirmOptions
                                                {
                                                    PaymentMethod = data?.stripe_payment_method,
                                                    ReturnUrl = data?.return_uri
                                                });

                                                result.payment_intent = paymentIntent;
                                                result.payment_operation_result = "Payment procedure initiated";
                                            }
                                            else
                                            {
                                                result.payment_operation_result = "Invalid hall object";
                                            }
                                        }
                                        else
                                        {
                                            result.payment_operation_result = "Invalid hall object";
                                        }
                                    }
                                    catch (Exception E)
                                    {
                                        result.payment_operation_result = "Internal server error";
                                    }
                                }
                                else
                                {
                                    result.payment_operation_result = "Internal server error";
                                }
                            }
                            else
                            {
                                result.payment_operation_result = "Internal server error";
                            }
                        }
                        else
                        {
                            result.payment_operation_result = "Internal server error";
                        }
                    }
                    else
                    {
                        result.payment_operation_result = "Internal server error";
                    }
                }
                else
                {
                    result.payment_operation_result = "Internal server error";
                }

            }
            else
            {
                result.payment_operation_result = "Internal server error";
            }

            return (ReturnType)(object)result;
        }

        public Task<ReturnType?> Update<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }
    }
}
