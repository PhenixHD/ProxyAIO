namespace ProxyAIO {
    internal class Runner {
        private static async Task Main(string[] args) {
            Storage.createAll();
            Console.CursorVisible = false;

            await Selector.Selection();
        }
    }
}