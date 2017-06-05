using System.Net.Http;
using MarketClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketClient
{
    public class SimpleCryptoHTTPClient : SimpleHTTPClient
    {

        public override T2 SendPostRequest<T1, T2>(string url, string user, string token, T1 item) where T2 : class
        {
            var response = SendPostRequest(url, user, token, item);
            return response == null ? null : FromJson<T2>(response);
        }

        public override string SendPostRequest<T1>(string url, string user, string token, T1 item)
        {
            var auth = new { user, token };
            JObject jsonItem = JObject.FromObject(item);
            jsonItem.Add("auth", JObject.FromObject(auth));
            StringContent content = new StringContent(jsonItem.ToString());
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(url, content).Result;
                var responseContent = result?.Content?.ReadAsStringAsync().Result;
                return responseContent;
            }
        }
    }
}
