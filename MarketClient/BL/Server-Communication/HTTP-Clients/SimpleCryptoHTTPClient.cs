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

        Int64 nonceInt;


        public SimpleCryptoHTTPClient(){
            /*
            Int64 sign = -1;
            Int64 year = (DateTime.Today.Year - 2016);//* (int)Math.Pow(10,19);
            year = year * (Int64)Math.Pow(10, 19);

            Int64 test = (Int64)Math.Pow(10, 19);
            Int64 month = DateTime.Today.Month;//* (int)Math.Pow(10, 17);
            month = month * (Int64)Math.Pow(10, 17);

            Int64 day = DateTime.Today.Day;//* (int)Math.Pow(10, 15);
            day = day * (Int64)Math.Pow(10, 15);

            Int64 hour = DateTime.Now.Hour;//* (int)Math.Pow(10, 13);
            hour = hour * (Int64)Math.Pow(10, 13);

            Int64 minutes = DateTime.Now.Minute;//* (int)Math.Pow(10, 11);
            minutes = minutes * (Int64)Math.Pow(10, 11);

            Int64 seconds = DateTime.Now.Second;//* (int)Math.Pow(10, 9);
            seconds = seconds * (Int64)Math.Pow(10, 9);

            Int64 miliseconds = DateTime.Now.Millisecond;// * (int)Math.Pow(10, 6);
            miliseconds = miliseconds * (Int64)Math.Pow(10, 6);

            nonceInt = year + month + day + hour + minutes + seconds + miliseconds;

            Trace.WriteLine(nonceInt);
            */


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


        public override string SendPostRequest<T1>(string url, string user_base, string privateKey, T1 item)
        {
            //string nonce = SimpleCtyptoLibrary.createNonce();

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

    }
}
