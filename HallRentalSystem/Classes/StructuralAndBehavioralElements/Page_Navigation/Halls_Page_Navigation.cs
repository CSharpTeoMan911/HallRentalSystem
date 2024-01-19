using Firebase.Database.Query;
using HallRentalSystem.Classes.API_Parameters;
using HallRentalSystem.Classes.Models;
using HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Page_Navigation
{
    public class Halls_Page_Navigation
    {
        public static async Task<string?> Navigate_To_Previous_Page(Halls_Pagination data, int elements_per_page)
        {
            string? serialised_json_result = null;
            string? serialised_result = null;

            ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");
            OrderQuery ordered_values = reference.OrderBy("Location");

            if (data.previous_pages_tokens != null)
            {

            }
            return "";
        }

        public static async Task<string?> Navigate_To_Current_Page(Halls_Pagination data, int elements_per_page)
        {
            string? serialised_json_result = null;
            string? serialised_result = null;

            ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");
            OrderQuery ordered_values = reference.OrderBy("Location");

            if (reference != null)
            {
                if (data.current_page_token != null)
                {
                    if (data.location_filter != null)
                    {
                        serialised_json_result = await ordered_values.EqualTo(data.location_filter).LimitToFirst(elements_per_page).StartAt(data.current_page_token).OnceAsJsonAsync(); ;
                    }
                    else
                    {
                        serialised_json_result = await ordered_values.LimitToFirst(elements_per_page).StartAt(data.current_page_token).OnceAsJsonAsync();
                    }
                }
                else
                {
                    if (data.location_filter != null)
                    {
                        serialised_json_result = await ordered_values.EqualTo(data.location_filter).LimitToFirst(elements_per_page).OnceAsJsonAsync(); ;
                    }
                    else
                    {
                        serialised_json_result = await ordered_values.LimitToFirst(elements_per_page).OnceAsJsonAsync();
                    }
                }


                if (serialised_json_result != null)
                {
                    Halls_Result? result = new Halls_Result();
                    Halls? halls = new Halls();

                    halls = Newtonsoft.Json.JsonConvert.DeserializeObject<Halls>(serialised_json_result);

                    //////////////////
                    // SERVER DEBUG //
                    //////////////////
                    //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(halls, Newtonsoft.Json.Formatting.Indented));

                    IEnumerable<string>? keys = halls?.Keys;

                    if (keys != null && keys?.Count() > 0)
                    {
                        string? current_key = keys.ElementAt(0);
                        result.halls = serialised_json_result;

                        if (current_key != null)
                        {
                            result.current_page_token = current_key;

                            string? current_last_key = keys.ElementAt(keys.Count() - 1);

                            serialised_json_result = await ordered_values.LimitToFirst(elements_per_page).StartAt(current_last_key).OnceAsJsonAsync();

                            if (serialised_json_result != null)
                            {
                                Halls? next_page = new Halls();
                                next_page = Newtonsoft.Json.JsonConvert.DeserializeObject<Halls>(serialised_json_result);
                                IEnumerable<string>? next_page_keys = next_page?.Keys;

                                if (next_page_keys != null)
                                {
                                    if (current_last_key == next_page_keys.ElementAt(next_page_keys.Count() - 1))
                                    {
                                        result.is_last = true;
                                    }
                                    else
                                    {
                                        result.next_page_token = next_page_keys.ElementAt(next_page_keys.Count() - 1);
                                    }
                                }
                            }

                            serialised_result = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
                        }
                    }
                }
            }

            return serialised_result;
        }

        public static async Task<string?> Navigate_To_Next_Page(Halls_Pagination data, int elements_per_page)
        {
            string? serialised_json_result = null;
            string? serialised_result = null;

            ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls/Hall_ID");
            OrderQuery ordered_values = reference.OrderBy("Location");
            
            if (reference != null)
            {
                if (data.next_page_token != null)
                {
                    if (data.location_filter != null)
                    {
                        serialised_json_result = await ordered_values.EqualTo(data.location_filter).LimitToFirst(elements_per_page).StartAt(data.next_page_token).OnceAsJsonAsync(); ;
                    }
                    else
                    {
                        serialised_json_result = await ordered_values.LimitToFirst(elements_per_page).StartAt(data.next_page_token).OnceAsJsonAsync();
                    }

                    if (serialised_json_result != null)
                    {
                        Halls_Result? result = new Halls_Result();
                        Halls? halls = new Halls();

                        halls = Newtonsoft.Json.JsonConvert.DeserializeObject<Halls>(serialised_json_result);

                        //////////////////
                        // SERVER DEBUG //
                        //////////////////
                        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(halls, Newtonsoft.Json.Formatting.Indented));

                        IEnumerable<string>? keys = halls?.Keys;

                        if (halls != null && keys?.Count() > 0)
                        {
                            if (keys.ElementAt(keys.Count() - 1) != data.current_page_token)
                            {

                            }
                        }
                    }
                }
            }

            return "";
        }
    }
}
