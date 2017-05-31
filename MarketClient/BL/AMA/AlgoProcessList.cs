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
        public ICommunicator comm;
        public int commodity;
        public int buyPrice;
        public int sellPrice;
        public int amount;
        public List<AlgoProcess> list;

        public IEnumerator<AlgoProcess> enumerator;

        public AlgoProcessList(AdvancedAMA ama, ICommunicator comm)
        {
            this.ama = ama;
            this.comm = comm;
            this.commodity = -1;
            this.buyPrice = -1;
            this.sellPrice = -1;
            this.amount = -1;
            this.enumerator = list.GetEnumerator();
        }


        public bool run()
        {
            AlgoProcess current = enumerator.Current;
            if (current == null) return false;

            bool success = current.runProcess(this);
            goToNextProcess(success);

            return success;
        }


        public void addAlgoProcess(AlgoProcess process)
        {
            list.Add(process);
        }
        
        public void goToNextProcess(bool next)
        {
            if (next)
            {
                if (!enumerator.MoveNext())
                {
                    enumerator = list.GetEnumerator();
                }
            }
        }

    }

    public interface AlgoProcess
    {
        bool runProcess(AlgoProcessList list);
    }
}
