using Newtonsoft.Json;
using Firebase.Database;
using System.Text;
using System.Text.Unicode;

namespace HallRentalSystem.Classes
{
    [AttributeUsage(AttributeTargets.All)]
    public class Firebase : Attribute
    {
        private static readonly string env_file_name = "FirebaseEnv.json";
        private static readonly string env_file_format = "{\r\n  \"FirebaseDatabaseURL\": \"YOUR_DATABASE_URL\",\r\n  \"FirebaseSecret\": \"YOUR_DATABASE_SECRET\"\n  ....\n  ....\n  ....\r\n}\r\n";

        public static FirebaseClient? firebaseClient = null;

        public Firebase()
        {

        }

        protected static async void InitiateFirebaseDatabase()
        {
            Firebase_Variables variables = await GetFirebaseEnvironmentValues();
            firebaseClient = new FirebaseClient(variables.FirebaseDatabaseURL, new FirebaseOptions { AuthTokenAsyncFactory = Task<string?> () => { return Task.FromResult(variables.FirebaseSecret); } });
        }


        private static async Task<Firebase_Variables> GetFirebaseEnvironmentValues()
        {
            Firebase_Variables? variables = null;

            try
            {
                FileStream file_reader = File.OpenRead(env_file_name);

                try
                {
                    byte[] file_contents = new byte[file_reader.Length];
                    await file_reader.ReadAsync(file_contents, 0, (int)file_reader.Length);
                    string file_contents_string = Encoding.UTF8.GetString(file_contents);
                    variables = JsonConvert.DeserializeObject<Firebase_Variables>(Encoding.UTF8.GetString(file_contents));
                }
                catch
                {

                }
                finally
                {
                    file_reader?.Dispose();
                }
            }
            catch
            {
                Create_Env_File();
                string msg = "Created the [ FirebaseEnv.json ] file. Go to your [ FirebaseEnv.json ]\n" +
                             "file add your Firebase database URL and Secret." +
                             "\n\n" + env_file_format;
                Console.WriteLine(msg);
                throw new Exception(msg);
            }


            if (variables == null)
                    variables = new Firebase_Variables();

            return variables;
        }


        private static async void Create_Env_File()
        {
            FileStream file_writer = File.OpenWrite(env_file_name);

            try
            {
                byte[] file_contents = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Firebase_Variables(), Formatting.Indented))));
                await file_writer.WriteAsync(file_contents, 0, file_contents.Length);
            }
            catch
            {

            }
            finally
            {
                file_writer?.Dispose();
            }
        }
    }
}
