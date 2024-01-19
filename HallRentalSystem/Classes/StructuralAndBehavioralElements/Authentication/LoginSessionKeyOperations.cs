using Firebase.Database.Query;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters;
using System.Security.Cryptography.Xml;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    public class LoginSessionKeyOperations : CRUD_Strategy<ChildQuery, string, string, string>
    {
        public async Task<ReturnType?> Delete<ReturnType>(string? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                if (data != null)
                {
                    ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");
                    Tuple<string, Type> hash_result = await Sha512Hasher.Hash(data);

                    if (hash_result.Item2 != typeof(Exception))
                    {
                        FilterQuery query = reference.OrderBy("Log_In_Session_Key").LimitToFirst(1).EqualTo(hash_result.Item1);
                        await query.DeleteAsync();
                        return (ReturnType)(object)"Logged out";
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
                return (ReturnType)(object)"Internal server error";
            }
        }

        public Task<ReturnType?> Get<ReturnType>(string? data)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnType?> Insert<ReturnType>(ChildQuery? data)
        {
            if (Firebase_Database.firebaseClient != null)
            {
                if (data != null)
                {
                    string? log_in_key = null;

                    for (int i = 0; i < 10; i++)
                    {
                        log_in_key = await Random_Log_In_Key_Generator.Generate();
                        Tuple<string, Type> key_hash_result = await Sha512Hasher.Hash(log_in_key);

                        if (key_hash_result.Item2 != typeof(Exception))
                        {
                            FilterQuery query = data.OrderBy("Log_In_Session_Key").EqualTo(key_hash_result.Item1).LimitToFirst(1);
                            string query_result = await query.OnceAsJsonAsync();
                            Log_In_Session_ID_Value? extracted_value = Newtonsoft.Json.JsonConvert.DeserializeObject<Log_In_Session_ID_Value>(query_result);

                            if (extracted_value == null)
                            {
                                return (ReturnType)(object)log_in_key;
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
