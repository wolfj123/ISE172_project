using System.Net.Http;
using MarketClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace MarketClient.BL
{
    public class SimpleCryptoHTTPClient : SimpleHTTPClient
    {
        //SIngleton design pattern
        private static readonly SimpleCryptoHTTPClient instance = new SimpleCryptoHTTPClient();
        private Int64 nonceInt;

        private SimpleCryptoHTTPClient(){
            string concat = "";
            concat += (DateTime.Today.Year - 2016).ToString();
            concat += DateTime.Today.ToString("MM");
            concat += DateTime.Today.ToString("dd");
            concat += DateTime.Now.ToString("HH");
            concat += DateTime.Now.ToString("mm");
            concat += DateTime.Now.ToString("ss");
            concat += DateTime.Now.ToString("fff");
            concat += "00000";

            nonceInt = Convert.ToInt64(concat);
            Trace.WriteLine(nonceInt);
        }

        public static SimpleCryptoHTTPClient getSimpleCryptoHTTPClient()
        {
            return instance;
        }


        public override string SendPostRequest<T1>(string url, string user_base, string privateKey, T1 item)
        {
            nonceInt += 1;
            string nonce = nonceInt.ToString();
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

        public string getNonce()
        {
            return nonceInt.ToString();
        } 

    }
}
