namespace ProxyAIO {
    internal class Selector {
        public static async Task<string> MainMenu() {
            Console.Clear();

            await Designer.AnimateText(Designer.GetMainMenuArt());
            await Designer.AnimateText(Designer.GetMainMenuSelection(), false, false);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char userSelection = keyInfo.KeyChar;

            switch (userSelection) {
                case '0':  //Exit
                    return "Exit";

                case '1':  //Proxy Scraper
                    return "ProxyScraper";

                case '2':  //Proxy Checker
                    return "ProxyChecker";

                case '3':  //Host Rotating
                    return "HostRotating";

                case '4':  //Settings
                    return "Settings";

                case '9':  //Information
                    return "Information";

                default:  //re-do
                    return "MainMenu";
            }
        }

        public static async Task Selection() {
            bool isRunning = true;
            string currentMenu = "MainMenu";

            while (isRunning) {
                switch (currentMenu) {
                    case "MainMenu":
                        currentMenu = await MainMenu();
                        break;

                    case "ProxyScraper":
                        Console.Clear();

                        string[] lines = File.ReadAllLines(Storage.UrlFilePath);
                        List<string> urls = lines.ToList();

                        var tasks = urls.Select(Modules.ProxyScraper.ParseProxies);

                        List<string>[] allProxies = await Task.WhenAll(tasks);
                        List<string> proxies = allProxies.SelectMany(proxies => proxies).ToList();

                        File.WriteAllLines(Storage.ProxyFilePath, proxies);

                        Console.WriteLine($"\n[Total Proxies: {proxies.Count}]");
                        Console.WriteLine("Pres [ENTER] to return");

                        currentMenu = "MainMenu";
                        Console.ReadKey();

                        break;

                    case "ProxyChecker":
                        break;

                    case "HostRotating":
                        break;

                    case "Settings":
                        Console.Clear();

                        await Designer.AnimateText(Designer.GetSettingArt());
                        await Designer.AnimateText(Designer.GetSettingsMenuSelection(), false, false);



                        Console.ReadKey();
                        currentMenu = "MainMenu";
                        break;

                    case "Information":
                        Console.Clear();

                        await Designer.AnimateText(Designer.GetInformationArt());
                        await Designer.AnimateText(Designer.GetInformationMenuSelection(), false, false);

                        Console.ReadKey();
                        currentMenu = "MainMenu";
                        break;

                    case "Exit":
                        isRunning = false;
                        break;

                    default:
                        currentMenu = "MainMenu";
                        break;
                }
            }
        }
    }
}