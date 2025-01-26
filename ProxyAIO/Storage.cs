﻿namespace ProxyAIO {
    internal class Storage {
        //creates all folders and URL file
        public static string MainDirectory { get; private set; }
        public static string ScraperDirectory { get; private set; }
        public static string CheckerDirectory { get; private set; }
        public static string ProxyFilePath => Path.Combine(ScraperDirectory, "Proxy.txt");
        public static string UrlFilePath => Path.Combine(ScraperDirectory, "URLs.txt");

        static Storage() {
            MainDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ProxyAIO");
            ScraperDirectory = Path.Combine(MainDirectory, "Proxy Scraper");
            CheckerDirectory = Path.Combine(MainDirectory, "Proxy Checker");
        }
        public static void createAll() {

            try {
                Directory.CreateDirectory(ScraperDirectory);
                Directory.CreateDirectory(CheckerDirectory);

                if (!File.Exists(UrlFilePath)) {
                    using (var fs = File.Create(UrlFilePath)) {
                        using (var sw = new StreamWriter(fs)) {
                            sw.WriteLine("# List of URLs to Scrape\n" +
                                "# Accepted Format [http|https]://[domain]");
                        }
                    }
                }

            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}