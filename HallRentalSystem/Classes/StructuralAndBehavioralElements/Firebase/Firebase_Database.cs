using Firebase.Database;
using Newtonsoft.Json;
using System.Text;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase
{
    [AttributeUsage(AttributeTargets.All)]
    public class Firebase_Database : Attribute
    {
        private static readonly string env_file_name = "FirebaseEnv.json";
        private static readonly string env_file_format = "{\r\n  \"FirebaseDatabaseURL\": \"YOUR_DATABASE_URL\",\r\n  \"FirebaseSecret\": \"YOUR_FIREBASE_PROJECT_API_SECRET\"\r\n}";

        public static FirebaseClient? firebaseClient = null;

        public Firebase_Database()
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
                FileStream file_reader = File.OpenRead(File_Path_Builder());

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
            FileStream file_writer = File.OpenWrite(File_Path_Builder());

            try
            {
                byte[] file_contents = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Firebase_Variables(), Formatting.Indented))));
                await file_writer.WriteAsync(file_contents, 0, file_contents.Length);
                await file_writer.FlushAsync();
            }
            catch
            {

            }
            finally
            {
                file_writer?.Dispose();
            }
        }


        private static string File_Path_Builder()
        {
            StringBuilder path_builder = new StringBuilder(new DirectoryInfo(Environment.CurrentDirectory)?.Parent?.Parent?.FullName);

            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX) == true)
            {
                path_builder.Append('/');
            }
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) == true)
            {
                path_builder.Append('/');
            }
            else
            {
                path_builder.Append('\\');

            }
            path_builder.Append(env_file_name);

            return path_builder.ToString();
        }
    }
}
