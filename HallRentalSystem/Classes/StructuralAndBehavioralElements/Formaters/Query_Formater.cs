using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters
{
    public class InnerTestObject
    {
        public string sTring { get; set; }
        public List<string> t { get; set; }
    }

    public class TrasnsistiveObject
    {
        public List<InnerTestObject>? t { get; set; }
    }
    public class TestObject
    {
        public string? s { get; set; }

        public TrasnsistiveObject? trasnsistiveObject { get; set; }

        public List<InnerTestObject>? t { get; set; }
    }

    public class Query_Formater
    {
        public static async Task<string> ObjectQueryFormatter<Object>(Object? value)
        {
            // STRING BUILDER OBJECT THAT CONTAINS THE FORMATED HTTP QUERY STRING
            StringBuilder query = new StringBuilder();

            // OBJECT TO BE FORMATED AS A HTTP QUERY STRING SERIALISED AS A JSON STRING AND PARSED INTO A "JObject" OBJECT
            JObject json_value = JObject.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(value));


            if (value != null)
            {
                // IF THE VALUE IS NOT NULL EXTRACT THE PARAMETERS OF THE "JObject" OBJECT AND FORMAT THEM IN HTTP QUERY STRING FORMAT
                await Query_Object_Parameters_Extractor(query, json_value, null);
            }

            // REMOVE ALL OBJECTS IN THE "JObject" OBJECT FROM THE MEMORY
            json_value?.RemoveAll();

            // RETURN THE FORMATED HTTP QUERY STRING
            return query.ToString();
        }


        private static async Task<bool> Query_Array_Parameters_Extractor(StringBuilder query, JArray json_value, string name)
        {
            // CREATE A "StringBuilder" TO GENERATE THE PROPRIETY NAME WITHIN IT
            StringBuilder name_builder = new StringBuilder();

            // ENUMERATE EACH PROPRIETY IN THE "JArray"
            for (int i = 0; i < json_value.Count; i++)
            {
                // STORE THE CURRENT PROPRIETY OF THE "JArray" OBJECT
                JToken current_element = json_value.ElementAt(i);

                name_builder.Append(name);
                name_builder.Append("[");
                name_builder.Append(i);
                name_builder.Append("]");

                string name_result = name_builder.ToString();
                name_builder.Clear();

                if (current_element.Type == JTokenType.Object)
                {
                    await Query_Object_Parameters_Extractor(query, (JObject)current_element, name_result);
                }
                else if (current_element.Type == JTokenType.Array)
                {
                    await Query_Array_Parameters_Extractor(query, (JArray)current_element, name_result);
                }
                else
                {
                    query.Append(System.Web.HttpUtility.UrlEncode(name_result));
                    query.Append("=");
                    query.Append(System.Web.HttpUtility.UrlEncode(json_value.ElementAt(i).ToString()));
                }

                if (i < json_value.Count - 1)
                {
                    query.Append("&");
                }
            }

            return true;
        }

        private static async Task<bool> Query_Object_Parameters_Extractor(StringBuilder query, JObject json_value, string? name)
        {
            // CREATE A "StringBuilder" TO GENERATE THE PROPRIETY NAME WITHIN IT
            StringBuilder name_builder = new StringBuilder();

            // GET ALL JSON PROPRIETIES OF THE "JObject" OBJECT
            IEnumerable<JProperty> proprieties = json_value.Properties();

            // ENUMERATE THROUGH THE PROPRIETIES OF THE "JObject" OBJECT WITH AN "IEnumerator"
            IEnumerator<JProperty> proprieties_enumerator = proprieties.GetEnumerator();

            try
            {
                // GET THE NUMBER OF PROPRIETIES WITHIN THE "JObject" OBJECT
                int count = proprieties.Count();

                // WHILE A PROPRIETY IS AVAILABLE WITHIN THE "IEnumerator"
                while (proprieties_enumerator.MoveNext() == true)
                {
                    // IF THE METHOD'S "name" PARAMETER IS NOT NULL
                    if (name != null)
                    {
                        // FOR EXAMPLE IF THE CURRENT PROPRIETY IS AN INNER OBJECT,
                        // APPEND THE CHILD OBJECT TO THE PARENT OBJECT NAME
                        // (e.g. PARENT OBJECT: calendarDates;
                        //       CHILD OBJECT: currentDate;
                        //       RESULTING OBJECT NAME: calendarDates.currentDate)

                        name_builder.Append(name);
                        name_builder.Append(".");
                        name_builder.Append(proprieties_enumerator.Current.Name);
                    }
                    else
                    {
                        // IF THE CURRENT PROPRIETY IS NOT AN INNER OBJECT, APPEND ONLY
                        // THE CURRENT PROPRIETY NAME
                        name_builder.Append(proprieties_enumerator.Current.Name);
                    }

                    // STORE THE PROCESSED PROPRIETY NAME IN A VARIABLE
                    string name_result = name_builder.ToString();
                    name_builder.Clear();

                    // IF THE CURRENT PROPRIETY IS A JSON OBJECT
                    if (proprieties_enumerator.Current.Value.Type == JTokenType.Object)
                    {
                        // PERFORM RECURSION AND PASS THE CURRENT OBJECT AS THE "JObject" OBJECT,
                        // THE "query" "StringBuilder" AS A REFERENCE, AND THE "name_result".
                        await Query_Object_Parameters_Extractor(query, (JObject)proprieties_enumerator.Current.Value, name_result);
                    }
                    // IF THE CURRENT PROPRIETY IS A JSON ARRAY
                    else if (proprieties_enumerator.Current.Value.Type == JTokenType.Array)
                    {
                        // CALL THE "Query_Array_Parameters_Extractor" METHOD TO EXTRACT THE VALUES
                        // FROM THE CURRENT "JArray" PROPRIETY.
                        await Query_Array_Parameters_Extractor(query, (JArray)proprieties_enumerator.Current.Value, name_result);
                    }
                    else
                    {
                        // FORMAT THE NAME OF THE PROPRIETY AND ITS VALUE AND ADD THEM IN THE "query" "StringBuilder"
                        // (e.g. PROPRIETY NAME: Query Test;
                        //       PROPRIETY VALUE: Testing;
                        //       RESULTING VALUE: Query+Test=Testing)

                        query.Append(System.Web.HttpUtility.UrlEncode(name_result));
                        query.Append("=");
                        query.Append(System.Web.HttpUtility.UrlEncode(proprieties_enumerator.Current.Value.ToString()));
                    }


                    // IF THE CURRENT JSON PROPRIETY IS NOT THE LAST ONE, APPEND "&"
                    // TO CONCATENATE THE PRECEDING ELEMENTS TO IT
                    // (e.g Query+Test=Testing&PRECEDING=1 )
                    if (count > 1)
                    {
                        query.Append("&");
                    }

                    // DECREMENT THE ELEMENT COUNT BY ONE AT EACH ITERATION
                    count--;
                }
            }
            catch
            {

            }
            finally
            {
                proprieties_enumerator?.Dispose();
                name_builder.Clear();
            }

            return true;
        }
    }
}
