namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    using System.Security.Cryptography;
    using System.Text;

    public class Random_Log_In_Key_Generator
    {
        private static List<char> symbols = new List<char> { '¬', '`', '¦', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '€', '-', '_', '=', '+', '[', '{', ']', '}', ';', ':', '\'', '@', '#', '~', ',', '<', '.', '>', '/', '?', '|', '\\' };
        private static List<char> letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static List<char> numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static Task<string> Generate()
        {
            StringBuilder key = new StringBuilder(40);

            for (int i = 0; i < 40; i++)
            {
                int option = RandomNumberGenerator.GetInt32(0, 3);

                switch (option)
                {
                    case 0:
                        int symbol_index = RandomNumberGenerator.GetInt32(0, symbols.Count);
                        key.Append(symbols.ElementAt(symbol_index));
                        break;
                    case 1:
                        int letters_index = RandomNumberGenerator.GetInt32(0, letters.Count);
                        key.Append(symbols.ElementAt(letters_index));
                        break;
                    case 3:
                        int numbers_index = RandomNumberGenerator.GetInt32(0, numbers.Count);
                        key.Append(symbols.ElementAt(numbers_index));
                        break;
                }
            }

            return Task.FromResult(key.ToString());
        }
    }
}
