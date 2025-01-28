namespace ProxyAIO.Core {
    internal class Validator {

        //Checks if url is valid format
        public static bool ValidateUrl(string url) {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result) &&
                  (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }

        //Checks if url is reachable
        public static async Task<bool> ReachableWebsite(string url) {
            using HttpClient client = new HttpClient {
                Timeout = TimeSpan.FromMilliseconds(3000)
            };

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                return true;
            }

            return false;
        }

        //Reads userinput and checks if within valid range + reset cursor to last pos before writing
        public static int ReadInteger(int minValid, int maxValid) {
            var cursorPos = Console.GetCursorPosition();
            int value;

            while (true) {

                Console.SetCursorPosition(cursorPos.Left, cursorPos.Top);
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out value) && value >= minValid && value <= maxValid) {
                    return value;
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\nInvalid Input. Try again!");
                    Console.SetCursorPosition(cursorPos.Left, cursorPos.Top);
                    Console.ResetColor();
                }

            }
        }

        //Reads userinput and checks if bool + reset cursor to last pos before writing
        public static bool ReadBool() {
            var cursorPos = Console.GetCursorPosition();
            bool value;

            while (true) {

                Console.SetCursorPosition(cursorPos.Left, cursorPos.Top);
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine();

                if (bool.TryParse(userInput, out value)) {
                    return value;
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\nInvalid Input. Try again!");
                    Console.SetCursorPosition(cursorPos.Left, cursorPos.Top);
                    Console.ResetColor();
                }

            }
        }

    }
}