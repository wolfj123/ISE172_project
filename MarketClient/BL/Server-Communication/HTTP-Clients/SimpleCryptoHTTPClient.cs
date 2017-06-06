using System.Net.Http;
using MarketClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketClient.BL
{
    public class SimpleCryptoHTTPClient : SimpleHTTPClient
    {
        public override string SendPostRequest<T1>(string url, string user_base, string privateKey, T1 item)
        {
            string nonce = SimpleCtyptoLibrary.createNonce();
            string user = user_base +"_"+ nonce;
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
