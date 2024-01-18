namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Formaters
{
    using System.Security.Cryptography;
    using System.Text;

    public class Sha512Hasher
    {
        private const string salt = "djahwsDKLJASEGJVHBSERJ23029Q04YTIFPWOLE;";
        public static async Task<Tuple<string, Type>> Hash(string? password)
        {
            StringBuilder hash_builder = new StringBuilder();
            hash_builder.Append(salt);
            hash_builder.Append(password);

            byte[] content = Encoding.UTF8.GetBytes(hash_builder.ToString());

            SHA512 hash = SHA512.Create();
            Stream stream = new MemoryStream();

            try
            {
                await stream.WriteAsync(content, 0, content.Length);
                await stream.FlushAsync();

                password = Encoding.UTF8.GetString(await hash.ComputeHashAsync(stream));
            }
            catch
            {
                try
                {
                    hash?.Dispose();
                    await stream.DisposeAsync();
                }
                catch { }
                return new Tuple<string, Type>("Internal server error", typeof(Exception));
            }
            finally
            {
                hash?.Dispose();
                await stream.DisposeAsync();
            }

            return new Tuple<string, Type>(password, typeof(string));
        }
    }
}
