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

        // USER LOG IN OPERATION
        public async Task<ReturnType?> Get<ReturnType>(Customer_ID_Value? data)
        {
            // IF THE FIREBASE DATABASE CLIENT IS NOT NULL
            if (Firebase_Database.firebaseClient != null)
            {
                // IF THE "Customer_ID_Value" OBJECT IS NOT NULL
                if (data != null)
                {
                    // VERIFY THE USER'S CREDTENTIALS AMD GET THE USER'S CREDENTIALS DATABASE ID
                    string result = await CredentialsVerification.Get_If_Email_And_Password_Are_Valid(data.Email, data.Password);

                    // IF THE RESULT OBJECT IS NOT EQUAL TO "Internal server error"
                    if (result != "Internal server error")
                    {
                        // IF THE RESULT OBJECT IS NOT EQUAL TO "Invalid email or password"
                        if (result != "Invalid email or password")
                        {
                            // GET THE DATABASE REFERENCE TO THE DATABASE NODE THAT STORES THE LOG IN SESSIONS
                            ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");

                            // CREATE A "Log_In_Session_ID_Value" OBJECT AND SET THE "Customer_ID" PROPRIETY FIELD
                            // AND THE "Expiration_Date" PROPRIETY FIELD AS THE CURRENT DATE AND TIME
                            Log_In_Session_ID_Value log_In_Session = new Log_In_Session_ID_Value();
                            log_In_Session.Customer_ID = result;
                            log_In_Session.Expiration_Date = DateTime.Now.AddHours(18);

                            // GENERATE AND INSERT A LOG IN SESSION KEY IN THE DATABASE
                            string? log_in_key = await Shared_Data.log_in_session.Insert<string>(log_In_Session);

                            // IF THE LOG IN SESSION KEY INSERTION IS SUCCESSFUL
                            if (log_in_key != "Internal server error")
                            {
                                // CREATE AN "Auth_Result" OBJECT
                                Auth_Result auth_Result = new Auth_Result();

                                // IF THE "log_in_key" STRING IS NOT NULL
                                if (log_in_key != null)
                                {
                                    // SET THE "Response" AND "Log_In_Key" PROPRIETY FIELDS
                                    // OF THE "Auth_Result" OBJECT
                                    auth_Result.Response = "Login successful";
                                    auth_Result.Log_In_Key = log_in_key;
                                }
                                // ELSE
                                else
                                {
                                    // SET THE SET THE "Response" PROPRIETY FIELD AS "Internal server error"
                                    auth_Result.Response = "Internal server error";
                                }

                                // SEARIALIZE THE "Auth_Result" OBJECT AS A JSON OBJECT
                                string serialised_result = Newtonsoft.Json.JsonConvert.SerializeObject(auth_Result);

                                // RETURN THE SERIALIZED JSON OBJECT
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


        // USER REGISTER OPERATION
        public async Task<ReturnType?> Insert<ReturnType>(Customer_ID_Value? data)
        {
            // IF THE FIREBASE DATABASE CLIENT IS NOT NULL
            if (Firebase_Database.firebaseClient != null)
            {
                // IF THE "Customer_ID_Value" OBJECT IS NOT NULL
                if (data != null)
                {
                    // CREATE AN "EmailAddressAttribute" OBJECT TO VALIDATE THE EMAIL ADDRESS FORMAT
                    EmailAddressAttribute email_validator = new EmailAddressAttribute();

                    // IF THE EMAIL ADDRESS GIVEN BY THE USER HAS A VALID FORMAT
                    if (email_validator.IsValid(data.Email) == true)
                    {
                        // IF THE EMAIL IS NOT NULL
                        if (data.Email != null)
                        {
                            // GET IF THE EMAIL EXISTS IN THE DATABASE
                            if (await CredentialsVerification.Get_If_Email_Exists(data.Email) == false)
                            {
                                // IF THE PASSWORD IS NOT NULL
                                if (data.Password != null)
                                {
                                    // IF THE PASSWORD IS GREATER OR EQUAL THAN 10 CHARACTERS IN LENGTH
                                    if (data.Password.Length >= 10)
                                    {
                                        // HASH AND SALT THE PASSWORD
                                        Tuple<string, Type> hash = await Sha512Hasher.Hash(data.Password);

                                        // IF THE HASHING OPERATION DID NOT RETURN AN EXCEPTIOM
                                        if (hash.Item2 != typeof(Exception))
                                        {
                                            // SET THE PASSWORD PROPRIETY FIELD OF THE "Customer_ID_Value" OBJECT AS THE HASHED AND SALTED PASSWORD
                                            data.Password = hash.Item1;

                                            // INSERT THE "Customer_ID_Value" OBJECT WITHIN THE DATABASE NODE THAT STORES ACCOUNTS
                                            FirebaseObject<Customer_ID_Value> result = await Firebase_Database.firebaseClient.Child("Customers/Customer_ID").PostAsync(data, false);

                                            // IF THE RESULT OF THE DATABASE OPERATION IS NOT NULL
                                            if (result.Object != null)
                                            {
                                                // RETURN "Registration successful"
                                                return (ReturnType)(object)"Registration successful";
                                            }
                                            // ELSE
                                            else
                                            {
                                                // RETURN "Invalid credentials"
                                                return (ReturnType)(object)"Invalid credentials";
                                            }
                                        }
                                        // ELSE
                                        else
                                        {
                                            // RETURN THE ERROR MESSAGE
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
