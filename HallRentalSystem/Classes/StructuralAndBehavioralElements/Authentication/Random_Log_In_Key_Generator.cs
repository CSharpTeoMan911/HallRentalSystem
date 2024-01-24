namespace HallRentalSystem.Classes.StructuralAndBehavioralElements.Authentication
{
    using System.Security.Cryptography;
    using System.Text;

    public class Random_Log_In_Key_Generator
    {
        // COLECTION OF CHARACTERS USED FOR THE RANDOM LOG IN SESSION KEY GENERATION
        private static List<char> symbols = new List<char> { '¬', '`', '¦', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '€', '-', '_', '=', '+', '[', '{', ']', '}', ';', ':', '\'', '@', '#', '~', ',', '<', '.', '>', '/', '?', '|', '\\' };
        private static List<char> letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static List<char> numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        // GENERATE A LOG IN SESSION KEY ASYNCHRONOUSLY
        public static Task<string> Generate()
        {
            // "StringBuilder" OBJECT THAT STORES A 40 CHARACTERS LONG STRING
            StringBuilder key = new StringBuilder(40);

            // CREATE A LOOP THAT LOOPS 40 TIMES
            for (int i = 0; i < 40; i++)
            {
                // GENERATE A RANDOM NUMBER BETWEEN 0 AND 2 USING A CRYPTOGRAPHICALLY SECURE RANDOM NUMBER GENERATOR
                int option = RandomNumberGenerator.GetInt32(0, 3);

                switch (option)
                {
                    // IF THE ABOVE GENERATED NUMBER IS 0
                    case 0:
                        // GET THE INDEX OF A SYMBOL BY USING A CRYPTOGRAPHICALLY SECURE RANDOM NUMBER GENERATOR 
                        int symbol_index = RandomNumberGenerator.GetInt32(0, symbols.Count);
                        // APPEND THE CHARACTER AT THE SPECIFIED RANDOMLY SELECTED INDEX
                        key.Append(symbols.ElementAt(symbol_index));
                        break;
                    case 1:
                        // GET THE INDEX OF A LETTER BY USING A CRYPTOGRAPHICALLY SECURE RANDOM NUMBER GENERATOR 
                        int letters_index = RandomNumberGenerator.GetInt32(0, letters.Count);
                        // APPEND THE LETTER AT THE SPECIFIED RANDOMLY SELECTED INDEX
                        key.Append(symbols.ElementAt(letters_index));
                        break;
                    case 2:
                        // GET THE INDEX OF A NUMBER BY USING A CRYPTOGRAPHICALLY SECURE RANDOM NUMBER GENERATOR 
                        int numbers_index = RandomNumberGenerator.GetInt32(0, numbers.Count);
                        // APPEND THE NUMBER AT THE SPECIFIED RANDOMLY SELECTED INDEX
                        key.Append(symbols.ElementAt(numbers_index));
                        break;
                }
            }

            // RETURN THE RANDOMLY GENERATED KEY
            return Task.FromResult(key.ToString());
        }
    }
}
