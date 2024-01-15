using Firebase.Database.Query;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{

    public class CredentialsVerification
    {
        public static async Task<bool> Get_If_Email_Exists(string email)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                string? current_page_token = null;
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Customers/Customers_ID");
                FilterQuery query = reference.OrderBy("Email").LimitToFirst(100);


                while (true)
                {
                    string result = await reference.OrderBy("Email").LimitToFirst(100).OnceAsJsonAsync();

                    if (result != null)
                    {
                        Customer_ID_Value? customers_value = null;
                        Customers? customers = Newtonsoft.Json.JsonConvert.DeserializeObject<Customers>(result);
                        customers?.TryGetValue(email, out customers_value);

                        if (customers_value != null)
                        {
                            return true;
                        }
                        else
                        {

                        }

                    }
                    else 
                    { 
                        break; 
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<bool> Get_If_Email_And_Password_Are_Valid(string email, string password)
        {
            return true;
        }

        public static async Task<bool> Insert_Account(string email, string password)
        {
            return true;
        }

        public static async Task<bool> Delete_Account(string email, string password)
        {
            return true;
        }
    }
}
