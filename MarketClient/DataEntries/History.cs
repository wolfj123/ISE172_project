using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.DataEntries
{
    public class History
    {
        private string userName;
        private string type;
        private string respose;
        private int amount;
        private int price;

        public History(string userName, string type, string respose, int amount, int price)
        {
            this.userName = userName;
            this.type = type;
            this.respose = respose;
            this.amount = amount;
            this.price = price;
        
        }

        public History(string userName, string type, int amount, int price)
        {
            this.userName = userName;
            this.type = type;
            this.amount = amount;
            this.price = price;

        }

        public string getUserNmae() { return userName; }

        public string getType() { return type; }

        public string getRespose() { return respose; }

        public int getAmount() { return amount; }

        public int getPrice() { return price; }

        public void setRespose(string newRespose) { respose = newRespose; }

    }
}
