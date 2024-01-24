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
        // DELETE THE LOG IN KEY FROM THE DATABASE
        public async Task<ReturnType?> Delete<ReturnType>(FirebaseKey? data)
        {
            // IF THE FIREBASE DATABASE CLIENT IS NOT NULL
            if (Firebase_Database.firebaseClient != null)
            {
                // IF THE LOG IN SESSION KEY GIVEN BY THE USER OBJECT IS NOT NULL
                if (data != null)
                {
                    // CREATE A REFERENCE TO THE DATABASE NODE THAT STORES THE LOG IN SESSIONS 
                    ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");

                    try
                    {
                        // DELETE THE CHILD NODE OF THE REFERENCE ABOVE WHERE THE LOG IN SESSION
                        // KEY EQUALS WITH THE LOG IN SESSION KEY GIVEN BY THE USER
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

        
        // INSERT A LOG IN SESSION KEY IN THE DATABASE
        public async Task<ReturnType?> Insert<ReturnType>(Log_In_Session_ID_Value? data)
        {
            // IF THE FIREBASE DATABASE CLIENT IS NOT NULL
            if (Firebase_Database.firebaseClient != null)
            {
                // CREATE A REFERENCE TO THE DATABASE NODE THAT STORES LOG IN SESSION KEYS
                ChildQuery reference = Firebase_Database.firebaseClient.Child("Log_In_Sessions/Log_In_Session_ID");

                // IF THE PROPRIETIES TO BE INSERTED IN THE DATABASE NEXT TO THE LOG IN SESSION KEY ARE NOT NULL 
                if (data != null)
                {
                    string? log_in_key = null;

                    // CREATE A FOR LOOP THAT LOOPS WHILE THE LOG IN SESSION KEY THAT IS GENERATED MATCHES ONE IN THE DATABASE.
                    // THE LOOP WILL TRY TO GENERATE AN UNIQUE LOG IN SESSION KEY 10 TIMES. IF THE GENERATED LOG IN SESSION
                    // KEY IS NOT UNIQUE, THE OPERATION WILL BE DROPPED AFTER THE 10th ITERATION.
                    for (int i = 0; i < 10; i++)
                    {
                        // GENERATE A LOG IN SESSION KEY
                        log_in_key = await Random_Log_In_Key_Generator.Generate();

                        // HASH AND SALT THE LOG IN SESSION KEY
                        Tuple<string, Type> key_hash_result = await Sha512Hasher.Hash(log_in_key);

                        // IF THE HASHING AND SALTING OPERATION IS SUCCESSFUL
                        if (key_hash_result.Item2 != typeof(Exception))
                        {
                            // GET THE LOG IN SESSION NODE THAT HAS THE VALUE EQUAL WITH THE GENERATED LOG IN SESSION KEY
                            FilterQuery query = reference.OrderBy("Log_In_Session_Key").EqualTo(key_hash_result.Item1).LimitToFirst(1);
                            
                            // GET THE NODE AS A JSON OBJECT
                            string query_result = await query.OnceAsJsonAsync();

                            // DESERIALIZE THE EXTRACTED NODE FROM A JSON OBJECT INTO A C# OBJECT
                            Log_In_Session_ID_Value? extracted_value = Newtonsoft.Json.JsonConvert.DeserializeObject<Log_In_Session_ID_Value>(query_result);

                            // IF THE DESERIALIZED OBJECT IS NULL
                            if (extracted_value == null)
                            {
                                // SET THE LOG IN SESSION KEY PROPRIETY FIELD FROM THE "Log_In_Session_ID_Value" OBJECT AS THE HASHED KEY
                                data.Log_In_Session_Key = key_hash_result.Item1;

                                // POST THE "Log_In_Session_ID_Value" OBJECT IN THE DATABASE NODE THAT STORES LOG IN SESSION KEYS 
                                FirebaseObject<Log_In_Session_ID_Value> post_result = await reference.PostAsync(data);


                                // CREATE A FIREBASE KEY OBJECT 
                                FirebaseKey key = new FirebaseKey();

                                // SET THE LOG IN SESSION KEY AS THE GENERATED KEY
                                key.log_in_session_key = log_in_key;

                                // SET THE DATABASE KEY AS THE EXTRACTED DATABASE KEY
                                key.database_key = post_result.Key;

                                // RETURN THE SERIALISED KEY AS A JSON OBJECT
                                return (ReturnType)(object)Newtonsoft.Json.JsonConvert.SerializeObject(key);
                            }
                            // ELSE
                            else
                            {
                                // IF THE GENERATED LOG IN SESSION KEY IS NOT EQUAL WITH THE EXTRATED LOG IN SESSION KEY FROM THE DATABASE
                                if (extracted_value?.Log_In_Session_Key != key_hash_result.Item1)
                                {
                                    // RETURN THE GENERATED LOG IN SESSION KEY
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
