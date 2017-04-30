using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient.DataEntries
{

    class RealHistory : History
    {

        private int id;
        private String user;
        private String type;
        private String status;
        private int amount;
        private int price;

        public RealHistory(int id, String user, String type, String status, int amount, int price)
        {
            this.id = id;
            this.type = type;
            this.status = status;
            this.amount = amount;
            this.price = price;
        }

        public int getId() { return id; }

        public String getUser() { return user; }

        public String getType() { return type; }

        public String getStatus() { return status; }

        public int getAmount() { return amount; }

        public int getPrice() { return price; }

        public void convertItem(History historyItem)
        {

    }
    
    }
}

