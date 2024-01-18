using Firebase.Database.Query;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{

    public class CredentialsVerification
    {
        public static async Task<bool> Get_If_Email_Exists(string? email)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customer_ID");
                FilterQuery query = reference.OrderBy("Email").EqualTo(email).LimitToFirst(1);
                string result = await query.OnceAsJsonAsync();
                if (result != null)
                {
                    Customers? customers = Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(result);

                    if (customers != null)
                    {
                        if (customers.Count > 0)
                        {
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

        public static async Task<bool> Get_If_Email_And_Password_Are_Valid(string? email, string? password)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customer_ID");
                FilterQuery query = reference.OrderBy("Email").EqualTo(email).LimitToFirst(1);
                string result = await query.OnceAsJsonAsync();
                if (result != null)
                {
                    Customers? customers = Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(result);

                    if (customers != null)
                    {
                        if (customers.Count == 1)
                        {
                            Customer_ID_Value? customer = new Customer_ID_Value();
                            customer = customers.ElementAt(0).Value;

                            Tuple<string, Type> hash_result = await Sha512Hasher.Hash(password);

                            if (hash_result.Item2 != typeof(Exception))
                            {
                                if (customer.Password == hash_result.Item1)
                                {
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
    }
}
