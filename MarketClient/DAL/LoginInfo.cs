using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DAL
{

    public class LoginInfo
    {
        public String url;
        public String username;
        public String token;

        public LoginInfo(String url, String username, String token)
        {
            this.url = url;
            this.username = username;
            this.token = token;
        }
    }

    public class DefaultLoginInfo
    {
        public DefaultLoginInfo()
        {
            

        }

    }

}
