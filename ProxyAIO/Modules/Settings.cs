namespace ProxyAIO.Modules {
    internal class Settings {

        public static int timeout { get; set; }

        static Settings() {
            timeout = Configuration.Settings.Default.Timeout;
        }

        public static async Task UpdateSettings() {
            Console.Clear();

            await Designer.AnimateText(Designer.GetSettingArt());
            await Designer.AnimateText(Designer.GetSettingsMenuSelection(), false, false);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char userSelection = keyInfo.KeyChar;

            Console.Clear();
            await Designer.AnimateText(Designer.GetSettingArt());

            switch (userSelection) {
                case '1':
                    await Designer.AnimateText($"Current Timeout: {timeout}s", false, false);
                    Console.Write("New Timeout: ");

                    Validator.ReadInteger(1, 20);
                    Configuration.Settings.Default.Save();
                    timeout = Configuration.Settings.Default.Timeout;

                    Console.WriteLine($"\nNew Timeout set!");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;

                default:
                    break;
            }
        }

    }
}