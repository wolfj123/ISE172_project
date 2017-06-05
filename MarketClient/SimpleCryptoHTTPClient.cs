using System.Net.Http;
using MarketClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketClient
{
    public class SimpleCryptoHTTPClient : SimpleHTTPClient
    {

        //TODO: SendPostRequest crypto
        

            /*
        public override T2 SendPostRequest<T1, T2>(string url, string user, string privateKey, T1 item) where T2 : class
        {
            var response = SendPostRequest(url, user, privateKey, item);
            return response == null ? null : FromJson<T2>(response);
        }

    */

        public override string SendPostRequest<T1>(string url, string user_base, string privateKey, T1 item)
        {
            string nonce = SimpleCtyptoLibrary.createNonce();
            string user = user_base + nonce;
            string token = SimpleCtyptoLibrary.CreateToken(user, privateKey);

            var auth = new { user, token, nonce };
            JObject jsonItem = JObject.FromObject(item);
            jsonItem.Add("auth", JObject.FromObject(auth));
            StringContent content = new StringContent(jsonItem.ToString());
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(url, content).Result;
                var responseContent = result?.Content?.ReadAsStringAsync().Result;

                try
                {
                    string decryptedContent = SimpleCtyptoLibrary.decrypt(responseContent, privateKey);
                    responseContent = decryptedContent;
                }
                finally { }
                return responseContent;

            }
        }

    }
}
