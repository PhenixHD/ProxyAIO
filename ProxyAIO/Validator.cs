namespace ProxyAIO {
    internal class Validator {

        //Checks if url is valid format
        public static bool ValidateUrl(string url) {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result) &&
                  (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }

        //Checks if url is reachable
        public static async Task<bool> ReachableWebsite(string url) {
            using HttpClient client = new HttpClient {
                Timeout = TimeSpan.FromMilliseconds(3000)
            };

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                return true;
            }

            return false;
        }

    }
}