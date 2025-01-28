using ProxyAIO.Utilities;

namespace ProxyAIO.Core {
    internal class Runner {
        private static async Task Main(string[] args) {
            Console.Title = "Proxy AIO";
            Storage.createAll();
            Console.CursorVisible = false;

            await Selector.Selection();
        }
    }
}