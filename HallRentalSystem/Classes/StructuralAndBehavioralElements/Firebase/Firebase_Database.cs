using Firebase.Database;
using Newtonsoft.Json;
using System.Text;

namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Firebase
{
    [AttributeUsage(AttributeTargets.All)]
    public class Firebase_Database : Attribute
    {
        private static readonly string env_file_name = "FirebaseEnv.json";
        private static readonly string env_file_format = "{\r\n  \"FirebaseDatabaseURL\": \"YOUR_DATABASE_URL\",\r\n " +
                                                        " \"FirebaseSecret\": \"YOUR_FIREBASE_PROJECT_API_SECRET\"\r\n}";

        public static FirebaseClient? firebaseClient = null;

        protected static async void InitiateFirebaseDatabase()
        {
            // GET THE DATABASE ENVIRONMENT VARIABLES ( DATABASE URL AND DATABASE SECRET )
            Firebase_Variables variables = await GetFirebaseEnvironmentValues();

            // ASSIGN THE EXTRACTED ENVIRONMENT VARIABLES TO THE FIREBASE DATABASE CLIENT
            firebaseClient = new FirebaseClient(variables.FirebaseDatabaseURL, new FirebaseOptions { AuthTokenAsyncFactory = Task<string?> () => { return Task.FromResult(variables.FirebaseSecret); } });
        }




        private static async Task<Firebase_Variables> GetFirebaseEnvironmentValues()
        {
            // CREATE AN OBJECT TO STORE THE FIREBASE VARIABLES
            Firebase_Variables? variables = null;

            try
            {
                // CREATE A "FileStream" OBJECT THAT ENABLES READ OPERATIONS ON THE "FirebaseEnv.json" FILE
                FileStream file_reader = File.OpenRead(File_Path_Builder());

                try
                {
                    // CREATE A BUFFER THAT STORES THE BINARY INFORMATION OF THE FILE AS BYTES
                    byte[] file_contents = new byte[file_reader.Length];

                    // READ THE BINARY INFORMATION OF THE FILE AND STORE IT IN THE BYTE BUFFER
                    await file_reader.ReadAsync(file_contents, 0, (int)file_reader.Length);

                    // CONVERT THE BINARY CONTENT OF THE FILE IN A STRING IN THE "UTF8" FORMAT
                    string file_contents_string = Encoding.UTF8.GetString(file_contents);

                    // DESEARIALIZE THE STRING CONTENT OF THE FILE FROM A JSON OBJECT INTO A C# OBJECT
                    variables = JsonConvert.DeserializeObject<Firebase_Variables>(Encoding.UTF8.GetString(file_contents));
                }
                catch
                {

                }
                finally
                {
                    // DEALLOCATE THE "FileStream" OBJECT FROM THE RAM MEMORY
                    file_reader?.Dispose();
                }
            }
            catch
            {
                // IF AN ERROR OCCURS WHEN THE FILE IS READ, THIS MEANS THAT THE FILE DOES NOT EXIST
                // AND AS A RESULT, AN EMPTY "FirebaseEnv.json" FILE IS CREATED IN THE ROOT DIRECTORY
                Create_Env_File();

                // GENERATE AN ERROR MESSAGE STRING
                string msg = "Created the [ FirebaseEnv.json ] file. Go to your [ FirebaseEnv.json ]\n" +
                             "file add your Firebase database URL and Secret." +
                             "\n\n" + env_file_format;

                // WRITE THE ERROR MESSAGE STRING ON THE SERVER'S APPLICATION CONSOLE WINDOW
                Console.WriteLine(msg);

                // THROW AN ERROR WITH THE ERROR MESSAGE SET
                throw new Exception(msg);
            }


            if (variables == null)
                variables = new Firebase_Variables();

            return variables;
        }


        private static async void Create_Env_File()
        {
            // CREATE A "FileStream" OBJECT THAT CRATES THE "FirebaseEnv.json" FILE AND ENABLES WRITE OPERATIONS ON THE FILE
            // AT THE PATH WERE THE ROOT FOLDER OF THE PROJECT EXIST USING THE "File_Path_Builder()" METHOD
            FileStream file_writer = File.OpenWrite(File_Path_Builder());

            try
            {
                // SERIALIZE THE "Firebase_Variables" OBJECT AS A JSON OBJECT, GET ITS BINARY INFORMATION, CONVERT IT INTO A "Base64" STRING, AND THEN GET THE BINARY INFORMATION OF THE "Base64" STRING
                byte[] file_contents = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Firebase_Variables(), Formatting.Indented))));

                // WRITE THE BINARY INFORMATION INTO THE "FirebaseEnv.json" FILE
                await file_writer.WriteAsync(file_contents, 0, file_contents.Length);

                // FLUSH ALL THE BINARY INFORMATION WITHIN THE STREAM WITHIN THE "FirebaseEnv.json" FILE
                await file_writer.FlushAsync();
            }
            catch
            {

            }
            finally
            {
                // DISPOSE THE "FileStream" OBJECT
                file_writer?.Dispose();
            }
        }


        private static string File_Path_Builder()
        {
            // CREATE A "StringBuilder" OBJECT AND SET AS ITS CONTENT THE PATH OF THE PROJECT'S ROOT DIRECTORY
            StringBuilder path_builder = new StringBuilder(new DirectoryInfo(Environment.CurrentDirectory)?.Parent?.Parent?.FullName);

            // IF THE CURRENT OPERATING SYSTEM IS WINDOWS
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows) == true)
            {
                // APPEND AS THE PATH SEPARATOR BETWEEN THE ROOT DIRECTORY'S PATH AND THE FILE NAME "\"
                path_builder.Append('\\');
            }
            // IF THE CURRENT OPERATING SYSTEM IS NOT WINDOWS
            else
            {
                // APPEND AS THE PATH SEPARATOR BETWEEN THE ROOT DIRECTORY'S PATH AND THE FILE NAME "/"
                path_builder.Append('/');

            }

            // APPEND IN THE "StringBuilder" OBJECT THE "FirebaseEnv.json" FILE NAME
            path_builder.Append(env_file_name);

            return path_builder.ToString();
        }
    }
}
