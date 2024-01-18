using Firebase.Database;
using Firebase.Database.Query;
using System.ComponentModel.DataAnnotations;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;
using System.Text;
using HallRentalSystem.Classes.Models;

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
                    /*
                    if (await CredentialsVerification.Get_If_Email_And_Password_Are_Valid(data.ElementAt(0).Value.Email, data.ElementAt(0).Value.Password) == true)
                    {
                        Log_In_Session_Value log_In_Session = new Log_In_Session_Value();
                        log_In_Session.Customer_ID = data.ElementAt(0).Key;
                        log_In_Session.Expiration_Date = DateTime.Now.AddHours(18);

                        FirebaseObject<Log_In_Session_Value> reference = await Firebase_Database.firebaseClient.Child("Customers/Log_In_Sessions").PostAsync(log_In_Session, false);

                        if (reference.Object.Expiration_Date == log_In_Session.Expiration_Date)
                        {
                            if (reference.Object.Customer_ID == log_In_Session.Customer_ID)
                            {
                                return (ReturnType)(object)"Log in successful";
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
                        return (ReturnType)(object)"Invalid email or password";
                    }
                     */
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
            return (ReturnType)(object)"Internal server error";
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
                        if (await CredentialsVerification.Get_If_Email_Exists(data.Email) == false)
                        {
                            if (data.Password != null)
                            {
                                if (data.Password.Length >= 10)
                                {

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
                                return (ReturnType)(object)"Invalid email address";
                            }
                        }
                        else
                        {
                            return (ReturnType)(object)"Email already in use";
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
                return (ReturnType)(object)"Internal server error".ToString();
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
