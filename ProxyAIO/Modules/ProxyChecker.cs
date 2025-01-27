using SocksSharp.Proxy;
using System.Net.Sockets;

namespace ProxyAIO.Modules {
    internal class ProxyChecker {

        public static async Task<List<string>> CheckProxies(string filePath) {

            string[] proxies = File.ReadAllLines(RemoveQuotes(filePath));
            List<string> workingProxies = new List<string>();

            foreach (string proxy in proxies) {
                try {

                    string[] proxyParts = proxy.Split(':');

                    if (proxyParts.Length == 2) {
                        string proxyHost = proxyParts[0].Trim();
                        int proxyPort = int.Parse(proxyParts[1].Trim());

                        Socks4 socks4Client = new Socks4();

                        socks4Client.Settings = new ProxySettings {
                            Host = proxyHost,
                            Port = proxyPort
                        };

                        using (TcpClient client = new TcpClient()) {
                            string destinationHost = "8.8.8.8";
                            int destinationPort = 53;

                            client.ReceiveTimeout = 5000;
                            client.SendTimeout = 5000;

                            try {
                                await client.ConnectAsync(proxyHost, proxyPort);
                                socks4Client.CreateConnection(destinationHost, destinationPort, client);

                                workingProxies.Add(proxy);
                                Console.WriteLine($"Working proxy: {proxy}");
                            } catch (SocketException ex) {
                                Console.WriteLine($"Socket exception for proxy {proxy}: {ex.Message}");
                            } catch (ProxyException ex) {
                                Console.WriteLine($"Proxy error for {proxy}: {ex.Message}");
                            } catch (Exception ex) {
                                Console.WriteLine($"General error for {proxy}: {ex.Message}");
                            }
                        }

                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Error processing proxy {proxy}: {ex.Message}");
                }
            }
            Console.ReadLine();
            return workingProxies;
        }

        private static string RemoveQuotes(string input) {
            if (!string.IsNullOrEmpty(input) && input.StartsWith("\"") && input.EndsWith("\"")) {
                return input.Substring(1, input.Length - 2);
            }
            return input;
        }
    }
}