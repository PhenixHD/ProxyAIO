using System.Net;
using System.Net.Security;

namespace ProxyAIO.Modules {
    internal class ProxyChecker {
        private static readonly object ConsoleLock = new object();
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(25);

        //Fuck me this is shit and was only to test how socks connection work
        //Recode is added to To-Do List together with dynamic checking for HTTP/s, Socks4/a & Socks5 checking at same time
        public static async Task<List<string>> CheckProxies(string filePath) {

            string[] proxies = File.ReadAllLines(RemoveQuotes(filePath));
            List<string> workingProxies = new List<string>();

            List<Task> tasks = new List<Task>();

            foreach (string proxy in proxies) {
                WebProxy curProxy = new WebProxy($"socks5://{proxy}");

                HttpClientHandler handler = new HttpClientHandler {
                    Proxy = curProxy,
                    ServerCertificateCustomValidationCallback = (request, cert, chain, errors) => true
                };

                HttpClient client = new HttpClient(handler);

                await semaphore.WaitAsync();

                tasks.Add(Task.Run(async () => {
                    try {
                        client.Timeout = TimeSpan.FromSeconds(3);
                        var response = await client.GetAsync("https://google.com");

                        lock (ConsoleLock) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"[GOOD] ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(proxy);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }

                        lock (workingProxies) {
                            workingProxies.Add(proxy);
                        }

                    } catch {
                        lock (ConsoleLock) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"[BAD] ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(proxy);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                    } finally {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
            Console.ReadLine();
            return workingProxies;
        }

        //Removes unwanted '"' From File Strings incase User Drag & Drops file and string gets '"' added at front and back
        private static string RemoveQuotes(string input) {
            if (!string.IsNullOrEmpty(input) && input.StartsWith("\"") && input.EndsWith("\"")) {
                return input.Substring(1, input.Length - 2);
            }
            return input;
        }
    }
}