namespace ProxyAIO.Modules {
    internal class Settings {

        public static int timeout { get; set; }
        public static bool removeDupe { get; set; }

        //This is prob. one of the worst code I've willingly written and not changed in this project.
        //To-Do Display settings in Main Menu, Update whole Line on invalid input to prevent overwriting characters
        static Settings() {
            timeout = Configuration.Settings.Default.Timeout;
            removeDupe = Configuration.Settings.Default.RemoveDupe;
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
                    await Designer.AnimateText($"Current Timeout: {timeout}s [Valid: 1-300]", false, false);
                    Console.Write("New Timeout: ");

                    Configuration.Settings.Default.Timeout = Validator.ReadInteger(1, 300);
                    Configuration.Settings.Default.Save();
                    timeout = Configuration.Settings.Default.Timeout;

                    Console.WriteLine($"\nUpdated Value");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;

                case '2':
                    await Designer.AnimateText($"Current: {removeDupe} [Valid: True | False]", false, false);
                    Console.Write("New Settings: ");

                    Configuration.Settings.Default.RemoveDupe = Validator.ReadBool();
                    Configuration.Settings.Default.Save();
                    removeDupe = Configuration.Settings.Default.RemoveDupe;

                    Console.WriteLine($"\nUpdated Value");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;

                default:
                    break;
            }
        }

    }
}