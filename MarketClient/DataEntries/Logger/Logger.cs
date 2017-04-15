using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries.Logger
{
    class Logger
    {
        public Logger() {
            string path = @"https://github.com/wolfj123/ISE172_project.git/Log";
            FileStream filestream = new FileStream(@"C:/MyFolder/Text.txt", FileMod.Append, FileAccess.Write);
            filestream.close();
        }

        public static void logging(IMarketRequest request)
        {
            RequestType request = request.getType();
            switch (request)
            {
                case "buy":

            }
        }
    }
}
