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

            Console.WriteLine($"Current Timeout for Parsing: {timeout}");
            Console.Write("Enter new Timeout in Seconds: ");

            Configuration.Settings.Default.Timeout = Convert.ToInt32(Console.ReadLine());
            Configuration.Settings.Default.Save();
            timeout = Configuration.Settings.Default.Timeout;

            Console.WriteLine($"New Timeout set!");

        }

    }
}
