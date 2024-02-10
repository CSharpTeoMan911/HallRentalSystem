using Firebase.Database.Query;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{

    public class CredentialsVerification
    {

        // VERIFY IF THE EMAIL ALREADY EXISTS IN THE DATABASE
        public static async Task<bool> Get_If_Email_Exists(string? email)
        {
            // IF THE FIREBASE DATABASE CLIENT IS NOT NULL
            if (Firebase_Database.firebaseClient != null)
            {
                // CREATE A REFERENCE TO THE DATABASE NODE RESPONSIBLE FOR STORING USE ACCOUNTS
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customer_ID");

                // GET THE FIELD THAT HAS THE EMAIL FIELD VALUE EQUAL WITH THE EMAIL GIVEN BY THE USER
                FilterQuery query = reference.OrderBy("Email").EqualTo(email).LimitToFirst(1);

                // GET THE EXTRACTED DATABASE NODE AS A JSON STRING
                string result = await query.OnceAsJsonAsync();

                // IF THE RESULT IS NOT NULL
                if (result != null)
                {
                    // DESERIALIZE THE EXTRACTED NODE FROM A JSON OBJECT INTO A C# OBJECT
                    Customers? customers = Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(result);

                    // IF THE DESERIALIZED OBJECT IS NOT NULL
                    if (customers != null)
                    {
                        // IF THE NUMBER OF CUSTOMERS IN THE OBJECT IS GREATER THAN 1
                        if (customers.Count > 0)
                        {
                            // SIGNAL THAT THE ACCOUNT WAS FOUND
                            return true;
                        }
                        else 
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // VERIFY IF THE EMAIL AND PASSWORD GIVEN BY THE USER ARE VALID
        public static async Task<string> Get_If_Email_And_Password_Are_Valid(string? email, string? password)
        {
            string result = "Internal server error";

            // IF THE FIREBASE DATABASE CLIENT IS NOT NULL
            if (Firebase_Database.firebaseClient != null)
            {
                // CREATE A REFERENCE TO THE DATABASE NODE THAT STORES USER ACCOUNTS
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customer_ID");
                
                // GET THE FIELD THAT HAS THE EMAIL PROPRIETY EQUAL WITH THE EMAIL GIVEN BY THE USER
                FilterQuery query = reference.OrderBy("Email").EqualTo(email).LimitToFirst(1);

                // GET THE EXTRACTED DATABASE NODE AS A JSON STRING
                string query_result = await query.OnceAsJsonAsync();

                // IF THE "query_result" IS NOT NULL
                if (query_result != null)
                {

                    // DESERIALIZE THE JSON OBJECT INTO A C# OBJECT
                    Customers? customers = Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(query_result);

                    // IF THE DESERIALIZED JSON OBJECT IS NOT NULL
                    if (customers != null)
                    {
                        // IF THE NUMBER OF CUSTOMERS WITHIN THE OBJECT IS EQUAL TO 1
                        if (customers.Count == 1)
                        {
                            // GET THE DATABASE KEY OF THE ACCOUNT
                            string customer_id = customers.ElementAt(0).Key;

                            // EXTRACT THE EMAIL AND PASSWORD FIELDS OF THE ACCOUNT
                            Customer_ID_Value? customer = new Customer_ID_Value();
                            customer = customers.ElementAt(0).Value;

                            // HASH AND SALT THE PASSWORD GIVEN BY THE USER
                            Tuple<string, Type> hash_result = await Sha512Hasher.Hash(password);
                            
                            // IF THE HASHING OPERATION SUCCEDED
                            if (hash_result.Item2 != typeof(Exception))
                            {
                                // IF THE HASED AND SALTED PASSWORD GIVEN BY THE USER IS EQUAL TO THE ONE EXTRATED FROM THE DATABASE
                                if (customer.Password == hash_result.Item1)
                                {
                                    return customer_id;
                                }
                                // ELSE
                                else
                                {
                                    // RETURN "Invalid email or password"
                                    result = "Invalid email or password";
                                }
                            }
                            // ELSE
                            else
                            {
                                // RETURN "Invalid email or password"
                                result = "Invalid email or password";
                            }
                        }
                        else
                        {
                            result = "Invalid email or password";
                        }
                    }
                    else
                    {
                        result = "Invalid email or password";
                    }
                }
                else
                {
                    result = "Invalid email or password";
                }
            }

            return result;
        }
    }
}
