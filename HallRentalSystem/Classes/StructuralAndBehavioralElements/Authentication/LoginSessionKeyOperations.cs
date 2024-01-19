using Firebase.Database;
using Firebase.Database.Query;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;
using System.Security.Cryptography.Xml;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    public class LoginSessionKeyOperations : CRUD_Strategy<Log_In_Session_ID_Value, string, string, FirebaseKey>
    {
        public async Task<ReturnType?> Delete<ReturnType>(FirebaseKey? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                if (data != null)
                {
                    ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");

                    try
                    {
                        await reference.Child(data.database_key).DeleteAsync();
                        return (ReturnType)(object)"Logged out";
                    }
                    catch
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
                return (ReturnType)(object)"Internal server error";
            }
        }

        public Task<ReturnType?> Get<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnType?> Insert<ReturnType>(Log_In_Session_ID_Value? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");

                if (data != null)
                {
                    string? log_in_key = null;

                    for (int i = 0; i < 10; i++)
                    {
                        log_in_key = await Random_Log_In_Key_Generator.Generate();
                        Tuple<string, Type> key_hash_result = await Sha512Hasher.Hash(log_in_key);

                        if (key_hash_result.Item2 != typeof(Exception))
                        {
                            FilterQuery query = reference.OrderBy("Log_In_Session_Key").EqualTo(key_hash_result.Item1).LimitToFirst(1);
                            string query_result = await query.OnceAsJsonAsync();
                            Log_In_Session_ID_Value? extracted_value = Newtonsoft.Json.JsonConvert.DeserializeObject<Log_In_Session_ID_Value>(query_result);

                            if (extracted_value == null)
                            {
                                data.Log_In_Session_Key = key_hash_result.Item1;
                                FirebaseObject<Log_In_Session_ID_Value> post_result = await reference.PostAsync(data);

                                FirebaseKey key = new FirebaseKey();
                                key.log_in_session_key = log_in_key;
                                key.database_key = post_result.Key;

                                return (ReturnType)(object)Newtonsoft.Json.JsonConvert.SerializeObject(key);
                            }
                            else
                            {
                                if (extracted_value?.Log_In_Session_Key == key_hash_result.Item1)
                                {
                                    return (ReturnType)(object)"Internal server error";
                                }
                                else
                                {
                                    return (ReturnType)(object)log_in_key;
                                }
                            }
                        }
                        else
                        {
                            return (ReturnType)(object)"Internal server error";
                        }
                    }
                    return (ReturnType)(object)"Internal server error";
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

        public Task<ReturnType?> Update<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }
    }
}
