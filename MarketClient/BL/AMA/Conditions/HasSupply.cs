using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class HasSupply : AlgoCondition
    {
        public bool conditionIsMet(AlgoProcess process)
        {
            //Get data from process
            IDictionary<string,int> userCommodities = process.agent.userData.getCommodities();
            string commodity = process.commodity.ToString();

            //Verify if amount>0
            if (userCommodities.ContainsKey(commodity))
            {
                int commoditySupply = userCommodities[commodity];
                return (commoditySupply > 0);
            }
            else
            {
                return false;
            }
        }
    }
}
