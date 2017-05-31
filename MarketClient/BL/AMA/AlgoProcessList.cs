using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class AlgoProcessList
    {
        public AdvancedAMA ama;
        public int commodity;
        public int buyPrice;
        public int sellPrice;
        public int amount;

        public List<AlgoActionProcess> list;

    }

    public interface AlgoActionProcess
    {
        bool runProcess(AlgoProcessList list);
    }
}
