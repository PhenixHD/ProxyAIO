using System.Text.RegularExpressions;

namespace ProxyAIO.Modules {
    internal class ProxyScraper {
        private static readonly object ConsoleLock = new object();

        public static async Task<List<string>> ParseProxies(string url) {
            using HttpClient client = new HttpClient {
                Timeout = TimeSpan.FromSeconds(Settings.timeout)
            };

            //Regex for Proxies + Make Empty list to prevent re-using full list due to multi-threading
            Regex proxyRegex = new Regex(@"\b\d{1,3}(?:\.\d{1,3}){3}:(?:[0-5]?\d{1,4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])\b", RegexOptions.Compiled);
            string rawData = string.Empty;
            List<string> validProxies = new List<string>();

            //Parse from URL and split into array by lines + extract regex matches + return
            try {
                rawData = await client.GetStringAsync(url);
                string[] lines = rawData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines) {
                    MatchCollection matches = proxyRegex.Matches(line);

                    foreach (Match match in matches) {
                        validProxies.Add(match.Value);
                    }
                }

                string proxyValue = $"[Proxies: {validProxies.Count}]";

                lock (ConsoleLock) {
                    if (validProxies.Count > 0) {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("[Success] ");
                    } else {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("[Empty]   ");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0,-17}", proxyValue);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{url}\n");
                    Console.ResetColor();
                }
            } catch (HttpRequestException) {
                string proxyValue = $"[Proxies: 0]";

                lock (ConsoleLock) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("[Failed]  ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0,-17}", proxyValue);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{url}\n");
                }
            } catch (TaskCanceledException) {
                string proxyValue = $"[Proxies: 0]";

                lock (ConsoleLock) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("[Timeout] ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0,-17}", proxyValue);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{url}");
                    Console.ResetColor();
                }
            } catch {
                lock (ConsoleLock) {
                    string proxyValue = $"[Proxies: 0]";

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("[Invalid] ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0,-17}", proxyValue);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{url}");
                    Console.ResetColor();
                }
            }
            return validProxies;
        }
    }
}