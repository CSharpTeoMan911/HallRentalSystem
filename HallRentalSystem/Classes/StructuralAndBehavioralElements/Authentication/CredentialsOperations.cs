using Firebase.Database;
using Firebase.Database.Query;
using System.ComponentModel.DataAnnotations;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.API_Payloads;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using System.Text;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    public class CredentialsOperations : CRUD_Strategy<Customer_ID_Value, Customer_ID_Value, Customers, string>
    {
        public async Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customers_ID");

                return (ReturnType)(object)true;
            }
            else
            {
                return (ReturnType)(object)false;
            }
        }

        public async Task<ReturnType?> Get<ReturnType>(Customer_ID_Value? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                if (data != null)
                {
                    string result = await CredentialsVerification.Get_If_Email_And_Password_Are_Valid(data.Email, data.Password);
                    if (result != "Internal server error")
                    {
                        if (result != "Invalid email or password")
                        {
                            ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");

                            Log_In_Session_ID_Value log_In_Session = new Log_In_Session_ID_Value();
                            log_In_Session.Customer_ID = result;
                            log_In_Session.Expiration_Date = DateTime.Now.AddHours(18);

                            string? log_in_key = await Shared_Data.log_in_session.Insert<string>(log_In_Session);

                            if (log_in_key != "Internal server error")
                            {
                                Auth_Result auth_Result = new Auth_Result();

                                if (log_in_key != null)
                                {
                                    auth_Result.Response = "Login successful";
                                    auth_Result.Log_In_Key = log_in_key;
                                }
                                else
                                {
                                    auth_Result.Response = "Internal server error";
                                }

                                string serialised_result = Newtonsoft.Json.JsonConvert.SerializeObject(auth_Result);
                                return (ReturnType)(object)serialised_result;
                            }
                            else
                            {
                                return (ReturnType)(object)"Internal server error";
                            }
                            
                        }
                        else
                        {
                            return (ReturnType)(object)"Invalid email or password";
                        }
                    }
                    else
                    {
                        return (ReturnType)(object)"Invalid email or password";
                    }
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

        public async Task<ReturnType?> Insert<ReturnType>(Customer_ID_Value? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                if (data != null)
                {
                    EmailAddressAttribute email_validator = new EmailAddressAttribute();

                    if (email_validator.IsValid(data.Email) == true)
                    {
                        if (data.Email != null)
                        {
                            if (await CredentialsVerification.Get_If_Email_Exists(data.Email) == false)
                            {
                                if (data.Password != null)
                                {
                                    if (data.Password.Length >= 10)
                                    {
                                        byte[] unformated_email = Encoding.UTF8.GetBytes(data.Email);
                                        data.Email = Convert.ToBase64String(unformated_email);

                                        Tuple<string, Type> hash = await Sha512Hasher.Hash(data.Password);

                                        if (hash.Item2 != typeof(Exception))
                                        {
                                            data.Password = hash.Item1;
                                            FirebaseObject<Customer_ID_Value> result = await Firebase_Database.firebaseClient.Child("Customers/Customer_ID").PostAsync(data, false);

                                            if (result.Object != null)
                                            {
                                                return (ReturnType)(object)"Registration successful";
                                            }
                                            else
                                            {
                                                return (ReturnType)(object)"Invalid credentials";
                                            }
                                        }
                                        else
                                        {
                                            return (ReturnType)(object)hash.Item1;
                                        }
                                    }
                                    else
                                    {
                                        return (ReturnType)(object)"Passowrd is less than 10 characters long";
                                    }
                                }
                                else
                                {
                                    return (ReturnType)(object)"Internal server error";
                                }
                            }
                            else
                            {
                                return (ReturnType)(object)"Email already in use";
                            }
                        }
                        else
                        {
                            return (ReturnType)(object)"Internal server error";
                        }
                    }
                    else
                    {
                        return (ReturnType)(object)"Invalid email address";
                    }
                }
                else
                {
                    return (ReturnType)(object)"Invalid email address";
                }
            }
            else
            {
                return (ReturnType)(object)"Internal server error";
            }
        }

        public async Task<ReturnType?> Update<ReturnType>(Customers? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customers_ID");

                return (ReturnType)(object)true;
            }
            else
            {
                return (ReturnType)(object)false;
            }
        }
    }
}
